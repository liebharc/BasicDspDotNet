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
    }
}
