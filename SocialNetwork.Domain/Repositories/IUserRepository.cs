using SocialNetwork.Domain.Models;

namespace SocialNetwork.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<int> InsertUserAsync(User user);
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByUsernameAsync(string username);
    }
}
