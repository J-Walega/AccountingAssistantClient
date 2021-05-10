using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingAssistantClient.Models;
using Caliburn.Micro;

namespace AccountingAssistantClient.ViewModels
{
    public class IncomeViewModel : Screen
    {
        private static Income _expense = new Income();

        public IncomeViewModel(Income income)
        {
            _expense = income;

            Number = income.Number;
            Buyer = income.Buyer;
            NIP = income.Nip;
            Name = income.Name;
            Netto = income.Netto;
            VAT = income.Vat;
            Brutto = income.Brutto;
            Category = income.Category;
            Paid = income.Paid.ToString();
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

        private string _buyer;
        public string Buyer
        {
            get { return _buyer; }
            set
            {
                _buyer = _expense.Buyer;
                NotifyOfPropertyChange(() => Buyer);
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
                if (_expense.Paid == true)
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
