using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
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

        public async Task<bool> PostExpense(ExpensePost expense)
        {
            var json = JsonConvert.SerializeObject(expense);
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/expense/store", expense))
            {
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                   MessageBox.Show(response.ReasonPhrase);
                   return false;
                }

            }
        }

        public async Task<bool> PatchExpense(PatchExpenseRequest expense)
        {
            var content = new StringContent(JsonConvert.SerializeObject(expense));
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PatchAsync(new Uri("http://localhost:8000/api/expense/update"), content))
            {
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase);
                    return false;
                }

            }
        }
    }
}
