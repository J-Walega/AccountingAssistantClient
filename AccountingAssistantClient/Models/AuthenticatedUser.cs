namespace AccountingAssistantClient.Models
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public int Expires_in { get; set; }
        public User User { get; set; }
    }
}
