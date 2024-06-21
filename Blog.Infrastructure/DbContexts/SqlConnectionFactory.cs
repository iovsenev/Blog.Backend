using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Blog.Infrastructure.DbContexts;
public class SqlConnectionFactory
{
    private readonly IConfiguration _configuration;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection() =>
        new NpgsqlConnection(_configuration.GetConnectionString("DatabaseAccess"));
}
