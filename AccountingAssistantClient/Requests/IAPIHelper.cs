using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AccountingAssistantClient.Models;

namespace AccountingAssistantClient.Requests
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
        Task<string> Login(string login, string password);
    }
}