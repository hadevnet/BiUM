using Microsoft.AspNetCore.Builder;

using Serilog;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureApp
{
    public static IApplicationBuilder AddInfrastructureApps(this IApplicationBuilder app)
    {
        var BiAppOrigins = "BiAppOrigins";

        // Configure Serilog logging
        app.UseSerilogRequestLogging();
        //app.UseSerilogExceptionHandler();

        app.UseCors(BiAppOrigins);

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = "swagger";
        });

        app.UseHealthChecks("/health");
        //app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}