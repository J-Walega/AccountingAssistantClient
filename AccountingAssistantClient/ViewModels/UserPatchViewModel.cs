using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AccountingAssistantClient.Models;
using AccountingAssistantClient.Requests;
using Caliburn.Micro;

namespace AccountingAssistantClient.ViewModels
{
    public class UserPatchViewModel : Screen
    {
        private IAdminEndpoints _adminEndpoints;
        private User _selectedUser;

        public UserPatchViewModel(IAdminEndpoints adminEndpoints, User selectedUser)
        {
            _adminEndpoints = adminEndpoints;
            _selectedUser = selectedUser;

            Name = selectedUser.Name;
            Email = selectedUser.Email;
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

        public async Task UpdateButton()
        {
            var request = new UserPatchRequest()
            {
                user_id = _selectedUser.Id,
                name = Name,
                role = "user",
                email = Email,
                password = Password,
                password_confirmation = RepeatPassword
            };

            var result = await _adminEndpoints.PatchSelectedUserAsync(request);
            if(result == true)
            {
                MessageBox.Show("Success");
                TryClose();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
