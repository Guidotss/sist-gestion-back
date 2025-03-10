using Domain.DataSources;
using Domain.Repositories;
using Infraestructure.Context;
using Infraestructure.DataSources;
using Infraestructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<DapperContext>();
        
        services.AddScoped<IUserDataSource, UserDataSourceImpl>();
        services.AddScoped<IUserRepository, UserRepositoryImpl>(); 

        return services; 
    }
}