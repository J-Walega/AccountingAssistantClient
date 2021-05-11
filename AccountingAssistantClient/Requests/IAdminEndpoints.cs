using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingAssistantClient.Models;

namespace AccountingAssistantClient.Requests
{
    public interface IAdminEndpoints
    {
        Task<List<User>> GetAllUsersAsync();
        Task<bool> PostExpenseToUser(ExpensePost expense);
        Task<bool> RegisterUserAsync(UserRegisterRequest request);
        Task<bool> DeleteSelectedUserAsync(User user);
        Task<bool> PatchSelectedUserAsync(UserPatchRequest request);
    }
}