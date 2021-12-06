using robot.Enum;
using robot.Interface;


namespace robot.Service
{
    public class MovementService : IMovementService
    {
        public void ExecSequence(IRobot robot, string commandSequence)
        {
            foreach (var commandChar in commandSequence)
            {
                var command = (Commands)System.Enum.Parse(typeof(Commands), commandChar.ToString());
                ExecCommand(robot, command);
            }
        }

        private void ExecCommand(IRobot robot, Commands command)
        {
            switch (command)
            {
                case Commands.L:
                case Commands.R:
                    Turn(robot, command);
                    break;
                case Commands.F:
                    Move(robot, command);
                    break;
            }
        }

        private void Turn(IRobot robot, Commands command)
        {
            int newDirection = (int)robot.Facing;

            if (command == Commands.L)
                newDirection = (int)robot.Facing - 1;
            else if (command == Commands.R)
                newDirection = (int)robot.Facing + 1;


            if (newDirection != (int)robot.Facing)
            {
                var dirLast = System.Enum.GetNames(typeof(Directions)).Length - 1;

                if (newDirection < 0)
                    newDirection = dirLast;
                else if (newDirection > dirLast)
                    newDirection = 0;

                robot.Facing = (Directions)newDirection;
            }
        }

        private void Move(IRobot robot, Commands command)
        {
            var newPositionX = robot.PositionX;
            var newPositionY = robot.PositionY;

            switch (robot.Facing)
            {
                case Directions.North:
                    newPositionY += 1;
                    break;
                case Directions.East:
                    newPositionX += 1;
                    break;
                case Directions.South:
                    newPositionY -= 1;
                    break;
                case Directions.West:
                    newPositionX -= 1;
                    break;
            }

            if (newPositionX != robot.PositionX && newPositionX <= robot.Plateau.Length && newPositionX > 0)
                robot.PositionX = newPositionX;

            if (newPositionY != robot.PositionY && newPositionY <= robot.Plateau.Width && newPositionY > 0)
                robot.PositionY = newPositionY;
        }
    }
}
