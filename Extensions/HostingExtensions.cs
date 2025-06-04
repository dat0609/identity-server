using Serilog;

namespace TeduMicroservice.IDP.Extensions;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // uncomment if you want to add a UI
        builder.Services.AddRazorPages();
        builder.Services.ConfigureIdentityServer(builder.Configuration);
        builder.Services.ConfigureIdentity(builder.Configuration);
        builder.Services.ConfigureCors();

        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();
    
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // uncomment if you want to add a UI
        app.UseStaticFiles();
        app.UseCors("CorsPolicy");
        app.UseRouting();
            
        app.UseIdentityServer();

        // uncomment if you want to add a UI
        app.UseAuthorization();
        app.UseEndpoints(end =>
        {
            end.MapDefaultControllerRoute();
            end.MapRazorPages().RequireAuthorization();
        });

        return app;
    }
}
