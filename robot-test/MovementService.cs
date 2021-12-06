using Microsoft.VisualStudio.TestTools.UnitTesting;
using robot.Class;
using robot.Enum;
using System.Numerics;

namespace robot_test
{
    [TestClass]
    public class MovementService
    {
        [TestMethod]
        public void Create()
        {
            const int noOfTestPlateau = 3;
            const int noOfTestCommands = 3;

            var plateaus = new Plateau[noOfTestPlateau]
            {
                new Plateau() { Length = 2, Width = 2 },
                new Plateau() { Length = 5, Width = 5 },
                new Plateau() { Length = BigInteger.Parse("2147483648"), Width = BigInteger.Parse("2147483648") }
            };

            var commands = new string[noOfTestCommands]
            {
                "RFF",
                "FFRFLFLF",
                "FFFFFRFFFFF"
            };

            Robot[,] correctState = new Robot[noOfTestPlateau, noOfTestCommands]
            {
                {
                    new Robot() { Facing = Directions.East, PositionX = 2, PositionY = 1 },
                    new Robot() { Facing = Directions.West, PositionX = 1, PositionY = 2 },
                    new Robot() { Facing = Directions.East, PositionX = 2, PositionY = 2 }
                },
                {
                    new Robot() { Facing = Directions.East, PositionX = 3, PositionY = 1 },
                    new Robot() { Facing = Directions.West, PositionX = 1, PositionY = 4 },
                    new Robot() { Facing = Directions.East, PositionX = 5, PositionY = 5 }
                },
                {
                    new Robot() { Facing = Directions.East, PositionX = 3, PositionY = 1 },
                    new Robot() { Facing = Directions.West, PositionX = 1, PositionY = 4 },
                    new Robot() { Facing = Directions.East, PositionX = 6, PositionY = 6 }
                }
            };

            var movementService = new robot.Service.MovementService();

            for (var i = 0; i < plateaus.Length; i++)
            {
                for (var j = 0; j < commands.Length; j++)
                {
                    var robot = new Robot()
                    {
                        Plateau = plateaus[i],
                        Facing = Directions.North,
                        PositionX = 1,
                        PositionY = 1
                    };

                    movementService.ExecSequence(robot, commands[j]);

                    Assert.AreEqual(robot.PositionX, correctState[i, j].PositionX);
                    Assert.AreEqual(robot.PositionY, correctState[i, j].PositionY);
                    Assert.AreEqual(robot.Facing, correctState[i, j].Facing);
                }
            }
        }
    }
}


