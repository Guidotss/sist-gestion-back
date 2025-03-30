using Domain.DataSources;
using Domain.Repositories;
using Domain.Services;
using Domain.UseCases;
using Domain.UseCases.Implementations;
using Infraestructure.Context;
using Infraestructure.DataSources;
using Infraestructure.Repositories;
using Infraestructure.Services;
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
        services.AddScoped<IAuthDataSource, AuthDataSourceImpl>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IJwtService, JwtService>();

        return services; 
    }
}