using System;
using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Services.Interfaces;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Types.IncentiveTypes.Support;
using Smartwyre.DeveloperTest.Types.Interfaces;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IRebateDataStore, RebateDataStore>()
            .AddSingleton<IProductDataStore, ProductDataStore>()
            .AddSingleton<IIncentiveTypeFactory, IncentiveTypeFactory>()
            .AddSingleton<IRebateService, RebateService>()
            .BuildServiceProvider();

        var rebateService = serviceProvider.GetService<IRebateService>();
        if (rebateService != null)
        {
            CalculateRebateRequest request = new CalculateRebateRequest(GetVolume(args));
            CalculateRebateResult result = rebateService.Calculate(request);

            Console.WriteLine(result.ToString());
            Console.WriteLine(result.Success);
        }
        else { Console.WriteLine("Failed to initialize rebateService"); }
    }

    static decimal GetVolume(string[] input)
    {
        if (input.Length == 0)
        {
            throw new ArgumentException("No argument was provided");
        }

        bool success = decimal.TryParse(input[0], out decimal volume);
        if (!success) 
        {
            throw new ArgumentException($"Failed to convert value {input} to decimal");
        }
        return volume;
    }
}
