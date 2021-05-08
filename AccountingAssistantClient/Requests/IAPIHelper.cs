using System.Threading.Tasks;
using AccountingAssistantClient.Models;

namespace AccountingAssistantClient.Requests
{
    public interface IAPIHelper
    {
        Task<bool> Login(string login, string password);
    }
}