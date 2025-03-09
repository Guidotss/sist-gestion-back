using Infraestructure.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<DapperContext>();
        

        return services; 
    }
}