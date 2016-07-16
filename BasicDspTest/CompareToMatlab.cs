using System;
using System.IO;
using System.Linq;
using BasicDsp;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicDspTest
{
    [TestClass]
    public class CompareToMatlab
    {
        private const int DataSize = 100000;

        private static MLApp.MLApp Matlab { get; } = new MLApp.MLApp();

        [TestInitialize]
        public void Init()
        {
            var cd = "cd \'" + Path.GetDirectoryName(GetType().Assembly.Location) + "\\..\\..\\..\'";
            Matlab.Execute(cd);
        }

        [TestMethod]
        public void SimpleOp()
        {
            var a = CreateRandomArray(DataSize);
            var b = CreateRandomArray(DataSize);
            Matlab.PutWorkspaceData("a", "base", a);
            Matlab.PutWorkspaceData("b", "base", b);
            object result = null;

            var start = DateTime.UtcNow;
            Matlab.Feval("mul_vector", 1, out result, "a=", "b=");
            var mDuration = DateTime.UtcNow - start;

            var doubles = GetDoubleArray(result);
            var vec1 = DataVector64.NewRealTimeVectorFromArray(a);
            var vec2 = DataVector64.NewRealTimeVectorFromArray(b);

            start = DateTime.UtcNow;
            var vecResult = vec1.Multiply(vec2);
            var vDuration = DateTime.UtcNow - start;
            Console.WriteLine("MATLAB: " + mDuration + " vs. Lib: " + vDuration);

            var res = VecToDoubles(vecResult);
            res.Should().Equal(doubles, (l, r) => Math.Abs(l - r) < 1e-4);
        }

        [TestMethod]
        public void DiffTest()
        {
            var a = CreateRandomArray(DataSize);
            Matlab.PutWorkspaceData("a", "base", a);
            object result = null;

            var start = DateTime.UtcNow;
            Matlab.Feval("diff_vector", 1, out result, "a=");
            var mDuration = DateTime.UtcNow - start;

            var doubles = GetDoubleArray(result);
            var vec1 = DataVector64.NewRealTimeVectorFromArray(a);

            start = DateTime.UtcNow;
            var vecResult = vec1.Diff();
            var vDuration = DateTime.UtcNow - start;
            Console.WriteLine("MATLAB: " + mDuration + " vs. Lib: " + vDuration);

            var res = VecToDoubles(vecResult);
            res.Should().Equal(doubles, (l, r) => Math.Abs(l - r) < 1e-4);
        }

        [TestMethod]
        public void UnwrapPosTest()
        {
            var a = Enumerable.Range(0, DataSize).Select(i => (double)i).ToArray();
            Matlab.PutWorkspaceData("a", "base", a);
            object result = null;

            var start = DateTime.UtcNow;
            Matlab.Feval("unwrap_vector", 1, out result, "a=");
            var mDuration = DateTime.UtcNow - start;

            var doubles = GetDoubleArray(result);
            var vec1 = DataVector64.NewRealTimeVectorFromArray(a);

            start = DateTime.UtcNow;
            var vecResult = vec1.Unwrap(2 * Math.PI);
            var vDuration = DateTime.UtcNow - start;
            Console.WriteLine("MATLAB: " + mDuration + " vs. Lib: " + vDuration);

            var res = VecToDoubles(vecResult);
            res.Should().Equal(doubles, (l, r) => Math.Abs(l - r) < 1e-4);
        }

        [TestMethod]
        public void UnwrapNegTest()
        {
            var a = Enumerable.Range(0, DataSize).Select(i => (double)-i).ToArray();
            Matlab.PutWorkspaceData("a", "base", a);
            object result = null;

            var start = DateTime.UtcNow;
            Matlab.Feval("unwrap_vector", 1, out result, "a=");
            var mDuration = DateTime.UtcNow - start;

            var doubles = GetDoubleArray(result);
            var vec1 = DataVector64.NewRealTimeVectorFromArray(a);

            start = DateTime.UtcNow;
            var vecResult = vec1.Unwrap(2 * Math.PI);
            var vDuration = DateTime.UtcNow - start;
            Console.WriteLine("MATLAB: " + mDuration + " vs. Lib: " + vDuration);

            var res = VecToDoubles(vecResult);
            res.Should().Equal(doubles, (l, r) => Math.Abs(l - r) < 1e-4);
        }

        [TestMethod]
        public void MultiOpsTest()
        {
            var aData = CreateRandomArray(100);
            var bData = CreateRandomArray(100);
            Matlab.PutWorkspaceData("a", "base", aData);
            Matlab.PutWorkspaceData("b", "base", bData);
            object result = null;

            var start = DateTime.UtcNow;
            Matlab.Feval("multi_ops2", 1, out result, "a=", "b=");
            var mDuration = DateTime.UtcNow - start;

            var doubles = GetDoubleArray(result);
            var vec1 = (DataVector64)DataVector64.NewRealTimeVectorFromArray(aData);
            var vec2 = (DataVector64)DataVector64.NewRealTimeVectorFromArray(bData);
            var ops = new PreparedOps2F64();
            ops.AddOps((a, b) =>
            {
                a.ToComplex();
                a.Sqrt();
                a.AddComplex(new Complex64(0.5, 0));
                a.Magnitude();
                b.MulVector(a);
            });
            var vDuration = DateTime.UtcNow - start;
            ops.Exec(vec1, vec2);
            Console.WriteLine("MATLAB: " + mDuration + " vs. Lib: " + vDuration);

            var res = VecToDoubles(vec2);
            res.Should().Equal(doubles, (l, r) => Math.Abs(l - r) < 1e-1);
        }

        private double[] CreateRandomArray(int length)
        {
            var random = new Random();
            var result = new double[length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = random.NextDouble() * 2 - 1;
            }

            return result;
        }

        private double[] GetDoubleArray(object result, int index = 0)
        {
            var results = (object[])result;
            var doubles = (double[,])results[index];
            var singleArray = new double[doubles.GetLength(1)];
            for (int i = 0; i < singleArray.Length; i++)
            {
                singleArray[i] = doubles[0, i];
            }
            return singleArray;
        }

        private double[] VecToDoubles(IDataVector64 vector)
        {
            var data = new double[vector.Length];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = vector[i];
            }

            return data;
        }
    }
}
