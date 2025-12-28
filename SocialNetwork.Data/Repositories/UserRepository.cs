using Dapper;
using SocialNetwork.Data.Factories;
using SocialNetwork.Domain.Models;
using SocialNetwork.Domain.Repositories;

namespace SocialNetwork.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UserRepository(IDbConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;

        public async Task<int> InsertUserAsync(User user)
        {
            const string sql = @"
                INSERT INTO users (first_name, last_name, date_of_birth, gender, interests, city, password_hash, username)
                VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @Interests, @City, @PasswordHash, @Username)
                RETURNING id";
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QuerySingleAsync<int>(sql, user);
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            const string sql = "SELECT id, first_name, last_name, date_of_birth, gender, interests, city FROM users WHERE id = @Id";
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            const string sql = @"
                                SELECT
                                    id,
                                    first_name AS FirstName,
                                    last_name AS LastName,
                                    date_of_birth::TIMESTAMP AS DateOfBirth,
                                    gender,
                                    interests,
                                    city,
                                    username,
                                    password_hash AS PasswordHash
                                FROM users
                                WHERE username = @Username";
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Username = username });
        }
    }
}