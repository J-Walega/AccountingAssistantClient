using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using AccountingAssistantClient.Models;
using AccountingAssistantClient.Requests;
using Caliburn.Micro;

namespace AccountingAssistantClient.ViewModels
{
    public class AdministratorViewModel : Screen
    {

        IAdminEndpoints _adminEndpoints;

        public AdministratorViewModel(IAdminEndpoints adminEndpoints)
        {
            _adminEndpoints = adminEndpoints;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadUsers();
        }

        private async Task LoadUsers()
        {
            var usersList = await _adminEndpoints.GetAllUsersAsync();
            Users = new BindingList<User>(usersList);
        }

        private BindingList<User> _users;
        public BindingList<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                NotifyOfPropertyChange(() => Users);
            }
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                NotifyOfPropertyChange(() => SelectedUser);
            }
        }

        public async Task RefreshUsersButton()
        {
            try
            {
                await LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
