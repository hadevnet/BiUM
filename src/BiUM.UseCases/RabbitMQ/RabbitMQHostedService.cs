using BiUM.Core.MessageBroker.RabbitMQ;
using BiUM.Core.Models.MessageBroker.RabbitMQ;

public class RabbitMQHostedService : IHostedService, IDisposable
{
    private readonly IRabbitMQClient _rabbitMQClient;
    private Timer _timer;

    public RabbitMQHostedService(IRabbitMQClient rabbitMQClient)
    {
        _rabbitMQClient = rabbitMQClient;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(SendMessageEvery10Seconds, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
        return Task.CompletedTask;
    }

    private void SendMessageEvery10Seconds(object state)
    {
        var message = new Message
        {
            Title = "Application is running",
            Body = "beatting",
            Timestamp = DateTime.UtcNow
        };

        _rabbitMQClient.SendMessage(message, queueName: "heart-beat");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    { }
}