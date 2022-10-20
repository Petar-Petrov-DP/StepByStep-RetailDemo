﻿using NServiceBus;

namespace Shipping
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Shipping";

            var endpointConfiguration = new EndpointConfiguration("Shipping");

            var transport = endpointConfiguration.UseTransport<LearningTransport>();

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();

            await endpointInstance.Stop()
                .ConfigureAwait(false);

        }
    }
}