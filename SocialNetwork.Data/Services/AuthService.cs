using SocialNetwork.Data.Helpers;
using SocialNetwork.Domain.Repositories;
using SocialNetwork.Domain.Results;
using SocialNetwork.Domain.Services;

namespace SocialNetwork.Data.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<AuthenticationResult> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null || !HelpFunctions.VerifyPassword(password, user.PasswordHash))
                return new AuthenticationResult { Success = false };

            return new AuthenticationResult { Success = true, UserId = user.Id };
        }
    }
}
