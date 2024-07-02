using BiUM.Core.Caching.Redis;
using BiUM.Core.Logging.Serilog;
using BiUM.Core.MessageBroker.RabbitMQ;
using BiUM.Infrastructure.Services.Caching.Redis;
using BiUM.Infrastructure.Services.Logging.Serilog;
using BiUM.Infrastructure.Services.MessageBroker.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;


namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add Redis Options
        // services.AddOptions<RedisClientOptions>()
        // .Configure<IConfiguration>((options, configuration) =>
        // {
        //     configuration.GetSection("RedisClientOptions").Bind(options);
        // });

        // services.AddScoped(sp => sp.GetRequiredService<IOptions<RedisClientOptions>>().Value);

        services.Configure<RedisClientOptions>(configuration.GetSection("RedisClientOptions"));
        services.AddDistributedMemoryCache(options => {
            configuration.GetSection("RedisClientOptions").Bind(options);
        });
        services.AddScoped<IRedisClient, RedisClient>();

        // Add RabbitMQ Options
        services.Configure<RabbitMQOptions>(configuration.GetSection("RabbitMQOptions"));
        services.AddOptions<RabbitMQOptions>()
        .Configure<IConfiguration>((options, configuration) =>
        {
            configuration.GetSection("RabbitMQOptions").Bind(options);
        });
        services.AddScoped<IRabbitMQClient, RabbitMQClient>();

        // Add Serilog logging
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog(dispose: true);
        });
        services.AddScoped<ISerilogClient, SerilogClient>();


        return services;
    }
}
