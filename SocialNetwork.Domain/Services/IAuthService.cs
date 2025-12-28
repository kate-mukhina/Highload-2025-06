using SocialNetwork.Domain.Results;

namespace SocialNetwork.Domain.Services
{
    public interface IAuthService
    {
        Task<AuthenticationResult> AuthenticateAsync(string username, string password);
    }
}
