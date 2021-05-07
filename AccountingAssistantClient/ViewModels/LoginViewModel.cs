using System;
using System.Threading.Tasks;
using System.Windows;
using AccountingAssistantClient.EventModels;
using AccountingAssistantClient.Models;
using AccountingAssistantClient.Requests;
using Caliburn.Micro;

namespace AccountingAssistantClient.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _login;
        private string _password;
        private IEventAggregator _events;

        private readonly LoginRequest request = new LoginRequest();

        public LoginViewModel(IEventAggregator events)
        {
            _events = events;
        }

        public string Login
        {
            get { return _login; }

            set
            {
                _login = value;
                NotifyOfPropertyChange(() => Login);
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
                var result = await request.Login(Login, Password);
                AuthenticatedUser loggedUser = new AuthenticatedUser
                {
                    Access_token = result.Access_token,
                    User = result.User
                };

                _events.PublishOnUIThread(new LogOnEvent());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
