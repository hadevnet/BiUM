using BiUM.Core.Authorization;
using BiUM.Core.Caching.Redis;
using BiUM.Core.Logging.Serilog;
using BiUM.Core.MessageBroker.RabbitMQ;
using BiUM.Core.Services;
using BiUM.Infrastructure.Interceptors;
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
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var BiAppOrigins = "BiAppOrigins";

        services.AddHttpContextAccessor();

        services.AddControllersWithViews();

        services.AddRazorPages();

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddCors(options =>
        {
            options.AddPolicy(name: BiAppOrigins,
                              policy =>
                              {
                                  policy
                                    .WithOrigins("http://localhost:3000")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod(); ;
                              });
        });

        services.AddHealthChecks();

        services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });

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
                configuration.GetSection(RabbitMQOptions.Name).Bind(options);
            });
        services.AddScoped<IRabbitMQClient, RabbitMQClient>();

        // Add Serilog logging
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog(dispose: true);
        });
        services.AddScoped<ISerilogClient, SerilogClient>();

        services.AddScoped<EntitySaveChangesInterceptor>();

        services.AddTransient<IDateTimeService, DateTimeService>();
        services.AddTransient<ICurrentUserService, CurrentUserService>();

        services.AddAuthentication();

        services.AddAuthorizationBuilder()
            .AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));

        return services;
    }

    public static IServiceCollection AddInfrastructureAdditionalServices(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
    {
        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly);
        services.AddMediatR(assembly);

        return services;
    }
}