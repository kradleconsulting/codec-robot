using robot.Enum;
using robot.Interface;
using System.Numerics;

namespace robot.Class
{
    public class Robot : IRobot
    {
        public IPlateau Plateau { get; set; }
        public Directions Facing { get; set; }
        public BigInteger PositionX { get; set; }
        public BigInteger PositionY { get; set; }
    }
}
