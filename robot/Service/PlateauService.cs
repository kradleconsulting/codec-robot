using robot.Class;
using robot.Interface;
using System.Numerics;

namespace robot.Service
{
    public class PlateauService : IPlateauService
    {
        public IPlateau Create(string dimensions) => new Plateau()
        {
            Length = BigInteger.Parse(dimensions.Split('x')[0]),
            Width = BigInteger.Parse(dimensions.Split('x')[1])
        };
    }
}
