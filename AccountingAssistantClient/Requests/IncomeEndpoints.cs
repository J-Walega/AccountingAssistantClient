using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AccountingAssistantClient.Models;

namespace AccountingAssistantClient.Requests
{
    public class IncomeEndpoints : IIncomeEndpoints
    {
        private IAPIHelper _apiHelper;
        private IAuthenticatedUser _authenticatedUser;
        public IncomeEndpoints(IAPIHelper apiHelper, IAuthenticatedUser authenticatedUser)
        {
            _apiHelper = apiHelper;
            _authenticatedUser = authenticatedUser;
        }

        public async Task<List<Income>> GetUserIncomesAsync()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"/api/income/show/{_authenticatedUser.User.Id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    List<List<Income>> data =
                         (List<List<Income>>)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<List<Income>>));
                    var list = data.SelectMany(x => x).ToList();
                    return list;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }

        public async Task<bool> PostUserIncome(IncomePost post)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/income/store", post))
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
    }
}
