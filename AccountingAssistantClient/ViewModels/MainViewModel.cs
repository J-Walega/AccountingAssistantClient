using Caliburn.Micro;

namespace AccountingAssistantClient.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        private LoginViewModel _loginVM;
        public MainViewModel(LoginViewModel loginVM)
        {
            _loginVM = loginVM;
            ActivateItem(_loginVM);
        }
    }
}
