using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using AccountingAssistantClient.EventModels;
using AccountingAssistantClient.Models;
using AccountingAssistantClient.Requests;
using Caliburn.Micro;

namespace AccountingAssistantClient.ViewModels
{
    public class LoggedViewModel : Screen
    {
        IExpensesEndpoint _expensesEndpoint;
        IIncomeEndpoints _incomeEndpoints;
        IWindowManager manager = new WindowManager();
        IAuthenticatedUser _authenticatedUser;

        public LoggedViewModel(IExpensesEndpoint expensesEndpoint, IIncomeEndpoints incomeEndpoints, IAuthenticatedUser authenticatedUser)
        {
            _expensesEndpoint = expensesEndpoint;
            _incomeEndpoints = incomeEndpoints;
            _authenticatedUser = authenticatedUser;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadExpenses();
            await LoadIncomes();
        }

        private async Task LoadExpenses()
        {
            var expensesList = await _expensesEndpoint.GetUserExpenses();
            Expenses = new BindingList<Expense>(expensesList);
        }

        private async Task LoadIncomes()
        {
            var incomesList = await _incomeEndpoints.GetUserIncomesAsync();
            Incomes = new BindingList<Income>(incomesList);
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

        private BindingList<Income> _incomes;
        public BindingList<Income> Incomes
        {
            get { return _incomes; }
            set 
            { 
                _incomes = value;
                NotifyOfPropertyChange(() => Incomes);
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

        private Income _selectedIncome;
        public Income SelectedIncome
        {
            get { return _selectedIncome; }
            set
            {
                _selectedIncome = value;
                NotifyOfPropertyChange(() => SelectedIncome);
            }
        }

        public void ReadExpenseButton()
        {
            if(_selectedExpense == null)
            {
                MessageBox.Show("Select expense");
            }
            else
            {
                var expense = new ExpenseViewModel(_selectedExpense);
                manager.ShowWindow(expense, null, null);
            }        
        }

        public void ReadIncomeButton()
        {
            if(_selectedIncome == null)
            {
                MessageBox.Show("Select income");
            }
            else
            {
                var income = new IncomeViewModel(_selectedIncome);
                manager.ShowWindow(income, null, null);
            }          
        }

        public void CreateExpenseButton()
        {
            var newExpenseCreatorViewModel = new ExpenseCreatorViewModel(_expensesEndpoint, _authenticatedUser);
            bool? result = manager.ShowDialog(newExpenseCreatorViewModel);
            //manager.ShowWindow(new ExpenseCreatorViewModel(_expensesEndpoint, _authenticatedUser), null, null);
        }

        public async Task RefreshButton()
        {
            await LoadExpenses();
            await LoadIncomes();
        }
    }
}
