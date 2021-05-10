using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingAssistantClient.Models;

namespace AccountingAssistantClient.Requests
{
    public interface IIncomeEndpoints
    {
        Task<List<Income>> GetUserIncomesAsync();
        Task<bool> PostUserIncome(IncomePost post);
    }
}