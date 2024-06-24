namespace BiUM.Infrastructure.Services.MessageBroker.RabbitMQ;

public class RabbitMQOptions
{
    public bool Enable { get; set; }
    public string? Hostname { get; set; }
    public int? Port { get; set; }
    public string? VirtualHost { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
}