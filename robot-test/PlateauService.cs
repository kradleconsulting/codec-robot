using Microsoft.VisualStudio.TestTools.UnitTesting;
using robot.Class;
using System.Numerics;


namespace robot_test
{
    [TestClass]
    public class PlateauService
    {
        [TestMethod]
        public void Create()
        {
            string[] dimensions = { "2x1", "3x3", "100x100", "9999999999999999999x9999999999999999999999" };
            Plateau[] correctState = {
                new Plateau(){ Length = 2, Width = 1},
                new Plateau(){ Length = 3, Width = 3},
                new Plateau(){ Length = 100, Width = 100},
                new Plateau(){ Length = BigInteger.Parse("9999999999999999999"), Width = BigInteger.Parse("9999999999999999999999")}
            };

            var plateauService = new robot.Service.PlateauService();

            for (var i = 0; i < dimensions.Length; i++)
            {
                var plateau = plateauService.Create(dimensions[i]);
                Assert.AreEqual(plateau.Length, correctState[i].Length);
                Assert.AreEqual(plateau.Width, correctState[i].Width);
            }
        }
    }
}
