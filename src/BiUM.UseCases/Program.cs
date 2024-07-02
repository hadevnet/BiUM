using BiUM.Core.Caching.Redis;
using BiUM.Core.MessageBroker.RabbitMQ;
using BiUM.Infrastructure.Services.Caching.Redis;
using BiUM.Infrastructure.Services.MessageBroker.RabbitMQ;
using BiUM.UseCases.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddApplicationServices();
    builder.Services.AddInfrastructureServices(builder.Configuration);

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // builder.Services.AddScoped<IRedisClient, RedisClient>();
    // builder.Services.AddScoped<IRabbitMQClient, RabbitMQClient>();

    // builder.Services.AddHostedService<RabbitMQHostedService>();
    // builder.Services.AddHostedService<RabbitMQListener>();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
