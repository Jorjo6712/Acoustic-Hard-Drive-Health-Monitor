using FastEndpoints.Swagger;
using hdd_health_monitor.Common.Interfaces;
using hdd_health_monitor.Common.Services;

namespace hdd_health_monitor.Host;

public static class DependencyInjection
{
    public static void AddWebApi(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        
        services.AddHttpContextAccessor();
        
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        
        services.AddOpenApi();

        services.AddFastEndpoints();

        builder.Services.SwaggerDocument();
    }
    
    public static void AddApplication(this IHostApplicationBuilder builder)
    {
        var applicationAssembly = typeof(DependencyInjection).Assembly;
        var services = builder.Services;
        
        services.AddValidatorsFromAssembly(applicationAssembly, includeInternalTypes: true);
    }
}