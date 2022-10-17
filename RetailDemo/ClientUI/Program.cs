
using NServiceBus;

static async Task AsyncMain()
{
    Console.Title = "ClinetUI";

    var endpointConfiguration = new EndpointConfiguration("ClientUI");

    var transport = endpointConfiguration.UseTransport<LearningTransport>();

    var endpointInstance = await Endpoint.Start(endpointConfiguration)
        .ConfigureAwait(false);

    Console.WriteLine("Press Enter to exit...");
    Console.ReadLine();

    await endpointInstance.Stop()
    .ConfigureAwait(false);
}