using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAssistantClient.Requests
{
    public class LoginRequest
    {
        public HttpClient Client { get; set; }

        LoginRequest()
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

        public async Task Login(string login, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("login", login),
                new KeyValuePair<string, string>("password", password)
            });

            using (HttpResponseMessage response = await Client.PostAsync("/Token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<string>();
                }
            }
        }
    }
}
