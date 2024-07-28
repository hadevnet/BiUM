using BiUM.Infrastructure.Services.Caching.Redis;
using BiUM.Infrastructure.Services.Logging.Serilog;
using BiUM.Infrastructure.Services.MessageBroker.RabbitMQ;

namespace BiUM.Infrastructure.Common.Configs;
public class Specialized
{
    public RedisClientOptions? RedisClientOptions { get; set; }
    public RabbitMQOptions? RabbitMQOptions { get; set; }
    public SerilogOptions? SerilogOptions { get; set; }
}