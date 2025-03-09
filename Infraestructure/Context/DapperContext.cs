using System.Data;
using Infraestructure.Adapters;
using Npgsql;



namespace Infraestructure.Context; 
public class DapperContext
{
    private readonly string _connectionString = Envs.Get("DB_CONNECTION_STRING");
    public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
}