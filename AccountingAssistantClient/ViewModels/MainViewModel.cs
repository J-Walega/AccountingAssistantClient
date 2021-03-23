using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
