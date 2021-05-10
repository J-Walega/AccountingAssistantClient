using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingAssistantClient.Models;
using AccountingAssistantClient.Requests;
using Caliburn.Micro;

namespace AccountingAssistantClient.ViewModels
{
    public class UserRegisterViewModel : Screen
    {
        private IAdminEndpoints _adminEndpoints;

        public UserRegisterViewModel(IAdminEndpoints adminEndpoints)
        {
            _adminEndpoints = adminEndpoints;
        }


        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        private string _role = "user";

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        private string _repeatPassword;

        public string RepeatPassword
        {
            get { return _repeatPassword; }
            set
            {
                _repeatPassword = value;
                NotifyOfPropertyChange(() => RepeatPassword);
            }
        }

        public async Task CreateButton()
        {
            var content = new UserRegisterRequest()
            {
                name = Name,
                role = "user",
                email = Email,
                password = Password,
                password_confirmation = RepeatPassword
            };

            var response = await _adminEndpoints.RegisterUserAsync(content);
            if(response == true)
            {
                TryClose();
            }
        }

    }
}
