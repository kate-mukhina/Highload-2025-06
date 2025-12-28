namespace SocialNetwork.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Interests { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Username { get; set; }
    }
}
