using SocialNetwork.Domain.Models;

namespace SocialNetwork.Domain.DTOs
{
    public record UserResponse(
          int Id,
          string FirstName,
          string LastName,
          DateTime DateOfBirth,
          string Gender,
          string Interests,
          string City
      );
}
