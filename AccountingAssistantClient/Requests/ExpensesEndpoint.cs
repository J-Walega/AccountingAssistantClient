using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AccountingAssistantClient.Models;
using Newtonsoft.Json;

namespace AccountingAssistantClient.Requests
{
    public class ExpensesEndpoint : IExpensesEndpoint
    {
        private IAPIHelper _apiHelper;
        private IAuthenticatedUser _authenticatedUser;
        public ExpensesEndpoint(IAPIHelper apiHelper, IAuthenticatedUser authenticatedUser)
        {
            _apiHelper = apiHelper;
            _authenticatedUser = authenticatedUser;
        }

        public async Task<List<Expense>> GetUserExpenses()
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"/api/expense/show/{_authenticatedUser.User.Id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                   List<List<Expense>> data = 
                        (List<List<Expense>>)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<List<Expense>>));
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
