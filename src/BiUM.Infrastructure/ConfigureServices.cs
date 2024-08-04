using BiUM.Core.Caching.Redis;
using BiUM.Core.MessageBroker.RabbitMQ;
using BiUM.Infrastructure.Common.Configs;
using BiUM.Infrastructure.Services;
using BiUM.Infrastructure.Services.Authorization;
using BiUM.Infrastructure.Services.Caching.Redis;
using BiUM.Infrastructure.Services.Logging.Serilog;
using BiUM.Infrastructure.Services.MessageBroker.RabbitMQ;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration, Specialized specialized = null)
    {

        if (specialized == null)
        {
            // Load settings from appsettings.json
            specialized = new Specialized();
            configuration.Bind(specialized);
        }

        // Configure Redis
        services.AddSingleton(specialized.RedisClientOptions);
        services.AddSingleton<IRedisClient, RedisClient>();

        // Configure RabbitMQ
        services.AddSingleton(specialized.RabbitMQOptions);
        services.AddSingleton<IRabbitMQClient, RabbitMQClient>();

        // TODO: Serilog getting Exception
        // Configure Serilog
        //var logger = new LoggerConfiguration()
        //    .MinimumLevel.Is(Enum.Parse<LogEventLevel>(specialized.SerilogOptions.MinimumLevel))
        //    .CreateLogger();


        // foreach (var writeTo in specialized.SerilogOptions.WriteTo)
        // {
        //     if (writeTo.Name == "Console")
        //     {
        //         logger.WriteTo.Console();
        //     }
        //     else if (writeTo.Name == "File")
        //     {
        //         logger.WriteTo.File(writeTo.Args["path"], rollingInterval: Enum.Parse<RollingInterval>(writeTo.Args["rollingInterval"]));
        //     }
        // }

        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog(dispose: true);
        });

        services.AddHealthChecks();

        // services.AddOptions<RedisClientOptions>();
        // services.Configure<RedisClientOptions>(configuration.GetSection("RedisClientOptions"));
        // services.AddDistributedMemoryCache(options =>
        // {
        //     configuration.GetSection("RedisClientOptions").Bind(options);
        // });
        // services.AddScoped<IRedisClient, RedisClient>();

        // // Add RabbitMQ Options
        // services.AddOptions<RabbitMQOptions>();
        // services.Configure<RabbitMQOptions>(configuration.GetSection("RabbitMQOptions"));
        // services.AddOptions<RabbitMQOptions>()
        //     .Configure<IConfiguration>((options, configuration) =>
        //     {
        //         configuration.GetSection(RabbitMQOptions.Name).Bind(options);
        //     });
        // services.AddScoped<IRabbitMQClient, RabbitMQClient>();

        // // Add Serilog logging
        // services.AddLogging(loggingBuilder =>
        // {
        //     loggingBuilder.ClearProviders();
        //     loggingBuilder.AddSerilog(dispose: true);
        // });
        // services.AddScoped<ISerilogClient, SerilogClient>();

        return services;
    }
}