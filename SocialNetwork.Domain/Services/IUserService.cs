using SocialNetwork.Domain.DTOs;
using SocialNetwork.Domain.Results;

namespace SocialNetwork.Domain.Services
{
    public interface IUserService
    {
        Task<RegistrationResult> RegisterAsync(RegisterRequest request);
        Task<UserResponse?> GetUserAsync(int id);
    }
}
