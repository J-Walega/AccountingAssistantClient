using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AccountingAssistantClient.Models;

namespace AccountingAssistantClient.Requests
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient Client;
        private IAuthenticatedUser _authenticatedUser;

        public APIHelper(IAuthenticatedUser authenticatedUser)
        {
            CreateClient();
            _authenticatedUser = authenticatedUser;
        }

        public HttpClient ApiClient
        {
            get
            {
                return Client;
            }
        }

        private void CreateClient()
        {
            string api = ConfigurationManager.AppSettings["api"];

            Client = new HttpClient();
            Client.BaseAddress = new Uri(api);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> Login(string login, string password)
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

                    _authenticatedUser.Access_token = result.Access_token;
                    _authenticatedUser.Expires_in = result.Expires_in;
                    _authenticatedUser.Token_type = result.Token_type;
                    _authenticatedUser.User = result.User;

                    Client.DefaultRequestHeaders.Clear();
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    Client.DefaultRequestHeaders.Add("Authorization", $"bearer { _authenticatedUser.Access_token }");

                    return true;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
