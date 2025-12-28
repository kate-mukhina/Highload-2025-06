using Npgsql;

namespace SocialNetwork.Data.Factories
{
    public interface IDbConnectionFactory
    {
        NpgsqlConnection CreateConnection();
    }
}