
using Messages.Commands;
using NServiceBus;
using NServiceBus.Logging;


static async Task AsyncMain()
{
    Console.Title = "ClinetUI";

    var endpointConfiguration = new EndpointConfiguration("ClientUI");

    var transport = endpointConfiguration.UseTransport<LearningTransport>();


    //Start the endpoint
    var endpointInstance = await Endpoint.Start(endpointConfiguration)
        .ConfigureAwait(false);

    RunLoop(endpointInstance);


    await endpointInstance.Stop()
    .ConfigureAwait(false);
}



static async Task RunLoop(IEndpointInstance endpointInstance)
{
    while (true)
    {
        log.Info("Press 'P' to place an order, or 'Q' to quit.");
        var key = Console.ReadKey();
        Console.WriteLine();

        switch (key.Key)
        {
            case ConsoleKey.P:
                // Instantiate the command
                var command = new PlaceOrder
                {
                    OrderId = Guid.NewGuid().ToString()
                };

                // Send the command to the local endpoint
                log.Info($"Sending PlaceOrder command, OrderId = {command.OrderId}");
                await endpointInstance.SendLocal(command)
                    .ConfigureAwait(false);

                break;

            case ConsoleKey.Q:
                return;

            default:
                log.Info("Unknown input. Please try again.");
                break;
        }
    }
}

public partial class Program
{
    static ILog log = LogManager.GetLogger<Program>();
}