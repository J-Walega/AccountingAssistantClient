using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingAssistantClient.Models;

namespace AccountingAssistantClient.Requests
{
    public interface IAdminEndpoints
    {
        Task<List<User>> GetAllUsersAsync();
        Task<bool> PostExpense(Expense expense);
        Task<bool> RegisterUserAsync(UserRegisterRequest request);
    }
}