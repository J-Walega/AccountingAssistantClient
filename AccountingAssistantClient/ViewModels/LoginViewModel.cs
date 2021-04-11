using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingAssistantClient.Requests;
using Caliburn.Micro;

namespace AccountingAssistantClient.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _email;
        private string _password;
        private ILoginRequest _loginRequest;

        public LoginViewModel(ILoginRequest loginRequest)
        {
            _loginRequest = loginRequest;
        }

        public string Email
        {
            get { return _email; }

            set
            {
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }

        public string Password
        {
            get { return _password; }

            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public async Task LoginButton()
        {
            try
            {
                var result = await _loginRequest.Login(Email, Password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
