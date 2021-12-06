using robot.Enum;
using robot.Interface;
using System;
using System.Numerics;

namespace robot.Class
{
    public class Mission
    {
        public string commandSequence;
        public string plateauDimensions;
        BigInteger startPositionX = 1;
        BigInteger startPositionY = 1;
        Directions startFacing = Directions.North;

        public IRobot robot;

        private IMovementService _movementService;
        private IPlateauService _plateauService;
        public Mission(IPlateauService plateauService, IMovementService movementService)
        {
            _plateauService = plateauService;
            _movementService = movementService;
        }

        private void Init()
        {
            Console.WriteLine("Enter plateau size ([Length]x[Width])");
            plateauDimensions = Console.ReadLine();
            Console.WriteLine("Enter commands sequence ([L|R|F])");
            commandSequence = Console.ReadLine();
            var plateau = _plateauService.Create(plateauDimensions);

            robot = new Robot
            {
                Plateau = plateau,
                PositionX = startPositionX,
                PositionY = startPositionY,
                Facing = startFacing
            };
        }

        private void Print()
        {
            Console.WriteLine($"{robot.PositionX},{robot.PositionY},{robot.Facing}");
        }

        public void Run()
        {

            Init();
            _movementService.ExecSequence(robot, commandSequence);
            Print();
        }

    }
}
