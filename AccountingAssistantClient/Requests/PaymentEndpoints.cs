using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AccountingAssistantClient.Models;

namespace AccountingAssistantClient.Requests
{
    public class PaymentEndpoints : IPaymentEndpoints
    {
        private IAPIHelper _apiHelper;
        private IAuthenticatedUser _authenticatedUser;
        public PaymentEndpoints(IAPIHelper apiHelper, IAuthenticatedUser authenticatedUser)
        {
            _apiHelper = apiHelper;
            _authenticatedUser = authenticatedUser;
        }

        public async Task<List<Payment>> GetUserPaymentsAsync()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"/api/payment/show/{_authenticatedUser.User.Id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    List<List<Payment>> data =
                         (List<List<Payment>>)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<List<Payment>>));
                    var list = data.SelectMany(x => x).ToList();
                    return list;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }

    }
}
