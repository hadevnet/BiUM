using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplicationServices(Assembly.GetExecutingAssembly());
    builder.Services.AddInfrastructureServices(builder.Configuration, Assembly.GetExecutingAssembly());
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");

    app.MapRazorPages();

    app.MapFallbackToFile("index.html");

    app.Run();
}