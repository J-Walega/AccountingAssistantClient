using System.Threading.Tasks;
using AccountingAssistantClient.Models;

namespace AccountingAssistantClient.Requests
{
    public interface ILoginRequest
    {
        Task<AuthenticatedUser> Login(string login, string password);
    }
}