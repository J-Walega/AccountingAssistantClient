using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountingAssistantClient.Models;
using AccountingAssistantClient.Requests;
using Caliburn.Micro;

namespace AccountingAssistantClient.ViewModels
{
    public class LoggedViewModel : Screen
    {
        IExpensesEndpoint _expensesEndpoint;

        public LoggedViewModel(IExpensesEndpoint expensesEndpoint)
        {
            _expensesEndpoint = expensesEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadExpenses();
        }

        private async Task LoadExpenses()
        {
            var expensesList = await _expensesEndpoint.GetUserExpenses();
            Expenses = new BindingList<Expense>(expensesList);
        }

        private BindingList<Expense> _expenses;
        public BindingList<Expense> Expenses
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

        private Expense _selectedExpense;

        public Expense SelectedExpense
        {
            get { return _selectedExpense; }
            set 
            {
                _selectedExpense = value;
                NotifyOfPropertyChange(() => SelectedExpense);
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
