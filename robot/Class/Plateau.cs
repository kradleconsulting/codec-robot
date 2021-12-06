using robot.Interface;
using System.Numerics;

namespace robot.Class
{
    public class Plateau : IPlateau
    {
        public BigInteger Length { get; set; }
        public BigInteger Width { get; set; }
    }
}
