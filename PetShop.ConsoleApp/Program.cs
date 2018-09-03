using System;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Impl;
using PetShop.Core.DomainService;
using PetShop.Infrastructure.Data;

namespace PetShop.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FakeDB.InitData();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var carService = serviceProvider.GetRequiredService<IPetService>();
            while (true)
            {
                Console.Clear();
                new Printer(carService);
                Console.WriteLine("\nHit enter to return to the main menu.", Console.ForegroundColor = ConsoleColor.DarkRed);
                Console.ReadLine();
            }

        }
    }
}
