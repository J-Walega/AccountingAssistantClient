using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AccountingAssistantClient.Models;

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
    }
}
