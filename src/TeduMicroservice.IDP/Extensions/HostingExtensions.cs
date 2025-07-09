using Serilog;
using TeduMicroservice.IDP.Common.Repositories;
using TeduMicroservice.IDP.Infra.Domain;
using TeduMicroservice.IDP.Infra.Repositories;
using TeduMicroservice.IDP.Services.EmailService;
using TeduMicroServices.IDP.Presentation;

namespace TeduMicroservice.IDP.Extensions;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // uncomment if you want to add a UI
        builder.Services.ConfigureIdentity(builder.Configuration);
        builder.Services.AddRazorPages();
        builder.Services.ConfigureIdentityServer(builder.Configuration);
        builder.Services.ConfigureCors();
        builder.Services.AddConfigurationSettings(builder.Configuration);
        builder.Services.AddScoped<IEmailSender, SmtpMailService>();
        builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
        builder.Services.AddTransient(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
        builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
        builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
        builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
        builder.Services.AddControllers((cfg =>
        {
            cfg.RespectBrowserAcceptHeader = true;
            cfg.ReturnHttpNotAcceptable = true;
        })).AddApplicationPart((typeof(AssemblyReference).Assembly));

        builder.Services.ConfigSwagger(builder.Configuration);
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
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("swagger/v1/swagger.json", "Tedu"));
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
