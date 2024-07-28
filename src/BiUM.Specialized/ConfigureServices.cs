using BiUM.Core.Caching.Redis;
using BiUM.Core.Logging.Serilog;
using BiUM.Core.MessageBroker.RabbitMQ;
using BiUM.Infrastructure.Common.Interceptors;
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
    public static IServiceCollection AddSpecializedServices(this IServiceCollection services, IConfiguration configuration)
    {
        var BiAppOrigins = "BiAppOrigins";

        services.AddHttpContextAccessor();

        services.AddControllersWithViews();

        services.AddRazorPages();

        services.AddCors(options =>
        {
            options.AddPolicy(name: BiAppOrigins,
                policy =>
                {
                    policy
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
        });

        services.AddControllers();

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);
        services.AddEndpointsApiExplorer();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });

        services.AddScoped<EntitySaveChangesInterceptor>();

        // services.AddTransient<IDateTimeService, DateTimeService>();
        // services.AddTransient<ICurrentUserService, CurrentUserService>();

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