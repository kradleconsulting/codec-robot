using Microsoft.Extensions.DependencyInjection;
using robot.Class;
using robot.Interface;
using robot.Service;
using System;

namespace robot
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IPlateauService, PlateauService>()
            .AddSingleton<IMovementService, MovementService>()
            .BuildServiceProvider();

            var plateauService = serviceProvider.GetService<IPlateauService>();
            var movementService = serviceProvider.GetService<IMovementService>();

            Mission mission = new Mission(plateauService, movementService);

            mission.Run();

            Console.ReadLine();
        }
    }
}
