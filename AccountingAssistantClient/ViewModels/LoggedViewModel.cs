using System.ComponentModel;
using Caliburn.Micro;

namespace AccountingAssistantClient.ViewModels
{
    public class LoggedViewModel : Screen
    {
        private BindingList<string> _expenses;

        public BindingList<string> Expenses
        {
            get { return _expenses; }
            set 
            { 
                _expenses = value;
                NotifyOfPropertyChange(() => Expenses);
            }
        }

        private BindingList<string> _invoices;

        public BindingList<string> Invoices
        {
            get { return _invoices; }
            set 
            { 
                _invoices = value;
                NotifyOfPropertyChange(() => Invoices);
            }
        }


        public bool CanRead
        {
            get
            {
                bool output = false;

                return output;
            }
        }

        public void ReadExpense()
        {

        }

        public void ReadInvoice()
        {

        }
    }
}
