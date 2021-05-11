using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingAssistantClient.Models;

namespace AccountingAssistantClient.Requests
{
    public interface IPaymentEndpoints
    {
        Task<List<Payment>> GetUserPaymentsAsync();
    }
}