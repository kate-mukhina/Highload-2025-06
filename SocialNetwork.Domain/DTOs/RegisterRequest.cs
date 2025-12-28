using SocialNetwork.Domain.Models;

namespace SocialNetwork.Domain.DTOs
{
    public record RegisterRequest(
        string FirstName,
        string LastName,
        DateTime DateOfBirth,
        string Gender,
        string Interests,
        string City,
        string Password,
        string Username
    );
}
