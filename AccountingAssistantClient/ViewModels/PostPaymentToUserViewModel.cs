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
    public class PostPaymentToUserViewModel : Screen
    {
        private IAdminEndpoints _adminEndpoints;
        private User _selectedUser;

        public PostPaymentToUserViewModel(IAdminEndpoints adminEndpoints, User selectedUser)
        {
            _adminEndpoints = adminEndpoints;
            _selectedUser = selectedUser;
        }

        private string _name;
        public string Name
        {
            get
            { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        private string _category;
        public string Category
        {
            get
            { return _category; }
            set
            {
                _category = value;
                NotifyOfPropertyChange(() => Category);
            }
        }

        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                NotifyOfPropertyChange(() => Value);
            }
        }

        public async Task SubmitButton()
        {
            var content = new PaymentPost()
            {
                user_id = _selectedUser.Id,
                name = Name,
                category = Category,
                value = Value
            };

            var response = await _adminEndpoints.PostPaymentToUser(content);
            if (response == true)
            {
                MessageBox.Show("Success");
                TryClose();
            }
        }
    }
}
