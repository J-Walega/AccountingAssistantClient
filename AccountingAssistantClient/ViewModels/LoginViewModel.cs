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
        private IAPIHelper _apiHelper;

        public LoginViewModel(IEventAggregator events, IAPIHelper apiHelper)
        {
            _events = events;
            _apiHelper = apiHelper;
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
                var result = await _apiHelper.Login(Login, Password);

                if(result == "user")
                {
                    _events.PublishOnUIThread(new LogOnEvent());
                }               
                else if (result == "admin")
                {
                    _events.PublishOnUIThread(new AdminLogOnEvent());
                }
                else
                {
                    MessageBox.Show("Login, password combination is wrong");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
