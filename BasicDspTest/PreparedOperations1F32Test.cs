using BasicDsp;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicDspTest
{
    [TestClass]
    public class PreparedOperations1F32Test
    {
        [TestMethod]
        public void PrepareOpsAndExecuteOnVector()
        {
            using (var ops = new PreparedOps1F32())
            using (var vector = DataVector32.NewRealTimeVectorFromConstant(2, 10))
            {
                ops.AddOps((v) =>
                {
                    v.AddReal(1.0f);
                    v.MultiplyReal(3.0f);
                });
                ops.Exec((DataVector32)vector);
                vector[0].Should().Be(9.0f);
            }
        }
    }
}
