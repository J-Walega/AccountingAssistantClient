using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingAssistantClient.Models;
using Caliburn.Micro;

namespace AccountingAssistantClient.ViewModels
{
    public class ExpenseViewModel : Screen
    {
        private static Expense _expense = new Expense();

        public ExpenseViewModel(Expense expense)
        {
            _expense = expense;

            Number = expense.Number;
            Seller = expense.Seller;
            NIP = expense.Nip;
            Name = expense.Name;
            Netto = expense.Netto;
            VAT = expense.Vat;
            Brutto = expense.Brutto;
            Category = expense.Category;
            Paid = expense.Paid.ToString();
        }

        private string _number;
        public string Number
        {
            get { return _number; }
            set 
            {
                _number = _expense.Number;
                NotifyOfPropertyChange(() => Number);
            }
        }

        private string _seller;
        public string Seller
        {
            get { return _seller; }
            set
            {
                _seller = _expense.Seller;
                NotifyOfPropertyChange(() => Seller);
            }
        }

        private long _nip;

        public long NIP
        {
            get { return _nip; }
            set 
            { 
                _nip = _expense.Nip;
                NotifyOfPropertyChange(() => NIP);
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = _expense.Name;
                NotifyOfPropertyChange(() => Name);
            }
        }

        private int _netto;

        public int Netto
        {
            get { return _netto; }
            set 
            { 
                _netto = _expense.Netto;
                NotifyOfPropertyChange(() => Netto);
            }
        }

        private int _vat;

        public int VAT
        {
            get { return _vat; }
            set 
            { 
                _vat = _expense.Vat;
                NotifyOfPropertyChange(() => VAT);
            }
        }

        private int _brutto;

        public int Brutto
        {
            get { return _brutto; }
            set 
            { 
                _brutto = _expense.Brutto;
                NotifyOfPropertyChange(() => Brutto);
            }
        }

        private string _category;

        public string Category
        {
            get { return _category; }
            set 
            { 
                _category = _expense.Category;
                NotifyOfPropertyChange(() => Category);
            }
        }

        private string _paid;

        public string Paid
        {
            get
            { return _paid; }
            set
            {
                if(_expense.Paid == true)
                {
                    _paid = "Yes";
                    NotifyOfPropertyChange(() => Paid);
                }
                else
                {
                    _paid = "No";
                    NotifyOfPropertyChange(() => Paid);
                }

            }
        }


        public void CloseButton()
        {
            TryClose();
        }


    }
}
