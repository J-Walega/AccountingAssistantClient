using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AccountingAssistantClient.Models;

namespace AccountingAssistantClient.Requests
{
    public interface IExpensesEndpoint
    {
        Task<List<Expense>> GetUserExpenses();
        Task<bool> PostExpense(ExpensePost content);
        Task<bool> PatchExpense(PatchExpenseRequest content);
    }
}