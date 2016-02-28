using System;
using BasicDsp;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicDspTest
{
    [TestClass]
    public class DataVector32Test
    {
        [TestMethod]
        [DeploymentItem("basic_dsp.dll")]
        public void AddRealValue()
        {
            using (var vector = DataVector32.NewRealTimeVectorFromConstant(2, 10))
            {
                vector.IsComplex.Should().BeFalse();
                vector.Length.Should().Be(10);
                vector.Points.Should().Be(10);
                vector.AllocatedLength.Should().Be(10);
                vector.Domain.Should().Be(VectorDomain.Time);
                vector[0].Should().BeApproximately(2.0f, 1e-15f);
                vector.Add(3);
                vector[0].Should().BeApproximately(5.0f, 1e-15f);
            }
        }

        [TestMethod]
        [DeploymentItem("basic_dsp.dll")]
        public void AddComplexValue()
        {
            using (var vector = DataVector32.NewComplexTimeVectorFromConstant(2, 10))
            {
                vector.IsComplex.Should().BeTrue();
                vector.Length.Should().Be(10);
                vector.Points.Should().Be(5);
                vector.AllocatedLength.Should().Be(10);
                vector.Domain.Should().Be(VectorDomain.Time);
                vector[0].Should().BeApproximately(2.0f, 1e-15f);
                vector[1].Should().BeApproximately(2.0f, 1e-15f);
                vector.Add(3, 2);
                vector[0].Should().BeApproximately(5.0f, 1e-15f);
                vector[1].Should().BeApproximately(4.0f, 1e-15f);
            }
        }

        [TestMethod]
        [DeploymentItem("basic_dsp.dll")]
        public void ExceptionTest()
        {
            using (var vector1 = DataVector32.NewRealTimeVectorFromConstant(2, 10))
            using (var vector2 = DataVector32.NewRealTimeVectorFromConstant(2, 11))
            {
                Action invalidMultiplication = () => vector1.Multiply(vector2);
                invalidMultiplication.ShouldThrow<VectorMustHaveTheSameSizeException>();
            }
        }

        [TestMethod]
        [DeploymentItem("basic_dsp.dll")]
        public void RealDotProduct()
        {
            using (var vector1 = DataVector32.NewRealTimeVectorFromConstant(2, 3))
            using (var vector2 = DataVector32.NewRealTimeVectorFromConstant(5, 3))
            {
                var result = vector1.RealDotProduct(vector2);
                result.Should().BeApproximately((float)(5 * 2 * 3), (float)1e-6);
            }
        }

        [TestMethod]
        [DeploymentItem("basic_dsp.dll")]
        public void ComplexDotProduct()
        {
            using (var vector1 = DataVector32.NewComplexTimeVectorFromConstant(2, 4))
            using (var vector2 = DataVector32.NewComplexTimeVectorFromConstant(5, 4))
            {
                var result = vector1.ComplexDotProduct(vector2);
                result.Real.Should().BeApproximately((float)(5 * 2 * 4), (float)1e-6);
            }
        }

        [TestMethod]
        [DeploymentItem("basic_dsp.dll")]
        public void RealStatistics()
        {
            using (var vector1 = DataVector32.NewRealTimeVectorFromConstant(2, 3))
            {
                var result = vector1.RealStatistics();
                result.Average.Should().BeApproximately(2.0f, (float)1e-6);
                result.Sum.Should().BeApproximately(6.0f, (float)1e-6);
            }
        }

        [TestMethod]
        [DeploymentItem("basic_dsp.dll")]
        public void ComplexStatistics()
        {
            using (var vector1 = DataVector32.NewComplexTimeVectorFromConstant(2, 4))
            {
                var result = vector1.ComplexStatistics();
                result.Average.Real.Should().BeApproximately(2.0f, (float)1e-6);
                result.Sum.Real.Should().BeApproximately(4.0f, (float)1e-6);
            }
        }

        [TestMethod]
        [DeploymentItem("basic_dsp.dll")]
        public void SplitInto()
        {
            using (var vector1 = DataVector32.NewComplexTimeVectorFromConstant(2, 4))
            using (var vector2 = DataVector32.NewComplexTimeVectorFromConstant(2, 4))
            using (var vector3 = DataVector32.NewComplexTimeVectorFromConstant(2, 4))
            {
                vector1.SplitInto(new[] { vector2, vector3 });
                vector2.Length.Should().Be(2);
                vector3.Length.Should().Be(2);
            }
        }

        [TestMethod]
        [DeploymentItem("basic_dsp.dll")]
        public void ComplexStatisticsSplitted()
        {
            using (var vector1 = DataVector32.NewComplexTimeVectorFromConstant(2, 4))
            {
                var result = vector1.ComplexStatisticsSplitted(2);
                result.Should().HaveCount(2);
                result[0].Count.Should().Be(1);
            }
        }

        private class TestWindowFunction : WindowFunction32
        {
            public bool HasBeenCalled { get; private set; }

            public override bool IsSymmetric => true;
            public override float Calculate(ulong n, ulong length)
            {
                HasBeenCalled = true;
                return 0.0f;
            }
        }

        [TestMethod]
        [DeploymentItem("basic_dsp.dll")]
        public void ApplyCustomWindow()
        {
            using (var vector1 = (DataVector32)DataVector32.NewComplexTimeVectorFromConstant(2, 4))
            {
                var window = new TestWindowFunction();
                vector1.ApplyWindow(window);
                window.HasBeenCalled.Should().BeTrue();
            }
        }

        [TestMethod]
        [DeploymentItem("basic_dsp.dll")]
        public void ZeroPad()
        {
            using (var vector1 = (DataVector32)DataVector32.NewComplexTimeVectorFromConstant(2, 4))
            {
                vector1.ZeroPad(10, PaddingOption.End);
                vector1.Length.Should().Be(20);
            }
        }
    }
}
