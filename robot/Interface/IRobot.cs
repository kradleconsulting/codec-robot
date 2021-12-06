using robot.Enum;
using System.Numerics;

namespace robot.Interface
{
    public interface IRobot
    {
        public Directions Facing { get; set; }
        public BigInteger PositionX { get; set; }
        public BigInteger PositionY { get; set; }
        public IPlateau Plateau { get; set; }
    }
}
