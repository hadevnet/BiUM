using BiUM.Core.Logging.Serilog;
using BiUM.Infrastructure.Services.MessageBroker.RabbitMQ;

namespace BiUM.UseCases.RabbitMQ;

public class RabbitMQListener : BackgroundService
{
    private readonly RabbitMQClient _rabbitMQClient;
    private readonly ISerilogClient _serilogClient;

    public RabbitMQListener(RabbitMQClient rabbitMQClient, ISerilogClient serilogClient)
    {
        _rabbitMQClient = rabbitMQClient;
        _serilogClient = serilogClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var message = await _rabbitMQClient!.ReceiveMessageAsync(queueName: "heart-beat");

        _serilogClient.Information(message.Title, message.Body);
    }
}
