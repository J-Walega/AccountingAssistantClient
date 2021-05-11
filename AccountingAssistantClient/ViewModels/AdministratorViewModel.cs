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
        IWindowManager manager = new WindowManager();

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

        public void CreateUserButton()
        {
            var newCreateUserViewModel = new UserRegisterViewModel(_adminEndpoints);
            bool? result = manager.ShowDialog(newCreateUserViewModel);
        }

        public void AddExpenseToUserButton()
        {
            var newPostExpenseToUserViewModel = new PostExpenseToUserViewModel(_adminEndpoints, _selectedUser);
            bool? result = manager.ShowDialog(newPostExpenseToUserViewModel);
        }

        public async Task DeleteUserButton()
        {
            var response = await _adminEndpoints.DeleteSelectedUserAsync(_selectedUser);
            if(response == true)
            {
                MessageBox.Show("Deleted successfully");
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }    
        }

        public void EditUserButton()
        {
            var newUserPatchViewModel = new UserPatchViewModel(_adminEndpoints, _selectedUser);
            bool? result = manager.ShowDialog(newUserPatchViewModel);
        }

    }
}
