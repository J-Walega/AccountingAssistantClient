using AccountingAssistantClient.EventModels;
using Caliburn.Micro;

namespace AccountingAssistantClient.ViewModels
{
    public class MainViewModel : Conductor<object>, IHandle<LogOnEvent>, IHandle<AdminLogOnEvent>
    {
        private IEventAggregator _events;
        private LoggedViewModel _loggedVM;
        private SimpleContainer _container;
        private AdministratorViewModel _adminVM;

        public MainViewModel(IEventAggregator events, LoggedViewModel loggedVM, AdministratorViewModel adminVM,
            SimpleContainer container)
        {
            _loggedVM = loggedVM;
            _adminVM = adminVM;

            _container = container;

            _events = events;
            _events.Subscribe(this);

            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_loggedVM);
        }

        public void Handle(AdminLogOnEvent message)
        {
            ActivateItem(_adminVM);
        }
    }
}
