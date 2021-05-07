using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AccountingAssistantClient.Models;

namespace AccountingAssistantClient.Requests
{
    public class LoginRequest : ILoginRequest
    {
        private HttpClient Client;

        public LoginRequest()
        {
            CreateClient();
        }

        private void CreateClient()
        {
            string api = ConfigurationManager.AppSettings["api"];

            Client = new HttpClient();
            Client.BaseAddress = new Uri(api);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticatedUser> Login(string login, string password)
        {

            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", login),
                new KeyValuePair<string, string>("password", password)
            });

            using (HttpResponseMessage response = await Client.PostAsync("/api/auth/login", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
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
