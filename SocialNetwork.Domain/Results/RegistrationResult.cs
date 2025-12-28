namespace SocialNetwork.Domain.Results
{
    public class RegistrationResult
    {
        public bool Success { get; set; }
        public int? UserId { get; set; }
        public string? Error { get; set; }
    }
}
