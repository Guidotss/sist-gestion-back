using System.Data;
using Microsoft.Extensions.Configuration; 
using Npgsql;



namespace Infraestructure.Context; 
public class DapperContext
{
    private readonly IConfiguration _config;
    private readonly string? _connectionString;

    public DapperContext(IConfiguration config)
    {
        _config = config;
        _connectionString = _config.GetConnectionString("DefaultConnection")  ?? throw new InvalidOperationException("Connection string not found");
    }
    
    public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
}