using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AccountingAssistantClient.Models;
using Newtonsoft.Json;

namespace AccountingAssistantClient.Requests
{
    public class AdminEndpoints : IAdminEndpoints
    {
        private IAPIHelper _apiHelper;
        private IAuthenticatedUser _authenticatedUser;

        public AdminEndpoints(IAPIHelper apiHelper, IAuthenticatedUser authenticatedUser)
        {
            _apiHelper = apiHelper;
            _authenticatedUser = authenticatedUser;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/auth/users"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<User>>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }

        public async Task<bool> PostExpenseToUser(ExpensePost expense)
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/expense/store", expense))
            {
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

        public async Task<bool> RegisterUserAsync(UserRegisterRequest request)
        {
            using (HttpResponseMessage respose = await _apiHelper.ApiClient.PostAsJsonAsync("/api/auth/register", request))
            {
                if (respose.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(respose.ReasonPhrase);
                    return false;
                }
            }
        }

        public async Task<bool> DeleteSelectedUserAsync(User request)
        {
            using (HttpResponseMessage respose = await _apiHelper.ApiClient.DeleteAsync($"/api/auth/destroy/{request.Id}"))
            {
                if (respose.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(respose.ReasonPhrase);
                    return false;
                }
            }
        }

        public async Task<bool> PatchSelectedUserAsync(UserPatchRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request));
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            using (HttpResponseMessage respose = await _apiHelper.ApiClient.PatchAsync(new Uri("http://localhost:8000/api/auth/update"), content))
            {
                if (respose.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(respose.ReasonPhrase);
                    return false;
                }
            }
        }

    }
}
