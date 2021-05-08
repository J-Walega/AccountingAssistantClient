namespace AccountingAssistantClient.Models
{
    public interface IAuthenticatedUser
    {
        string Access_token { get; set; }
        int Expires_in { get; set; }
        string Token_type { get; set; }
        User User { get; set; }
    }
}