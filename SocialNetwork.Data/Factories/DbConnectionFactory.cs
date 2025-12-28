using Npgsql;
using Microsoft.Extensions.Configuration;

namespace SocialNetwork.Data.Factories
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public NpgsqlConnection CreateConnection() => new(_connectionString);
    }
}