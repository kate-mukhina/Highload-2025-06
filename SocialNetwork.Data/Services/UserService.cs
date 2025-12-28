using SocialNetwork.Domain.DTOs;
using SocialNetwork.Domain.Services;
using SocialNetwork.Domain.Models;
using SocialNetwork.Domain.Results;
using SocialNetwork.Domain.Repositories;
using SocialNetwork.Data.Helpers;

namespace SocialNetwork.Data.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<RegistrationResult> RegisterAsync(RegisterRequest request)
        {
            // Простая валидация
            if (string.IsNullOrWhiteSpace(request.FirstName) ||
                string.IsNullOrWhiteSpace(request.LastName))
            {
                return new RegistrationResult
                {
                    Success = false,
                    Error = "Invalid input data"
                };
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                Interests = request.Interests,
                City = request.City,
                PasswordHash = HashPassword(request.Password),
                Username = request.Username
            };

            var userId = await _userRepository.InsertUserAsync(user);
            return new RegistrationResult { Success = true, UserId = userId };
        }

        public async Task<UserResponse?> GetUserAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return user != null
                ? new UserResponse(
                    user.Id, user.FirstName, user.LastName, user.DateOfBirth,
            user.Gender, user.Interests, user.City)
                : null;
        }

        private string HashPassword(string password) => HelpFunctions.HashPW(password);
    }
}
