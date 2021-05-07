using AccountingAssistantClient.EventModels;
using Caliburn.Micro;

namespace AccountingAssistantClient.ViewModels
{
    public class MainViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private LoggedViewModel _loggedVM;
        private SimpleContainer _container;

        public MainViewModel(IEventAggregator events, LoggedViewModel loggedVM,
            SimpleContainer container)
        {
            _loggedVM = loggedVM;

            _container = container;

            _events = events;
            _events.Subscribe(this);

            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_loggedVM);
        }
    }
}
