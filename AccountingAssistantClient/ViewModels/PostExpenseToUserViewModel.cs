using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingAssistantClient.Models;
using AccountingAssistantClient.Requests;
using Caliburn.Micro;

namespace AccountingAssistantClient.ViewModels
{
    public class PostExpenseToUserViewModel : Screen
    {
        private IAdminEndpoints _adminEndpoints;
        private User _selectedUser;

        public PostExpenseToUserViewModel(IAdminEndpoints adminEndpoints, User selectedUser)
        {
            _adminEndpoints = adminEndpoints;
            _selectedUser = selectedUser;
        }

        private string _number;
        public string Number
        {
            get { return _number; }
            set
            {
                _number = value;
                NotifyOfPropertyChange(() => Number);
            }
        }

        private string _seller;

        public string Seller
        {
            get { return _seller; }
            set
            {
                _seller = value;
                NotifyOfPropertyChange(() => Seller);
            }
        }

        private long _nip;

        public long NIP
        {
            get { return _nip; }
            set
            {
                _nip = value;
                NotifyOfPropertyChange(() => NIP);
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        private int _netto;

        public int Netto
        {
            get { return _netto; }
            set
            {
                _netto = value;
                NotifyOfPropertyChange(() => Netto);
            }
        }

        private int _vat;

        public int Vat
        {
            get { return _vat; }
            set
            {
                _vat = value;
                NotifyOfPropertyChange(() => Vat);
            }
        }

        private string _category;

        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                NotifyOfPropertyChange(() => Category);
            }
        }

        private bool _isPaid;

        public bool IsPaid
        {
            get { return _isPaid; }
            set
            {
                _isPaid = value;
                NotifyOfPropertyChange(() => IsPaid);
            }
        }

        public async Task SubmitButton()
        {
                var content = new ExpensePost()
                {
                    user_id = _selectedUser.Id,
                    number = Number,
                    date_issue = new DateTime(2021, 05, 11),
                    seller = Seller,
                    nip = NIP,
                    name = Name,
                    netto = Netto,
                    vat = Vat,
                    brutto = CalculateBrutto(Netto, Vat),
                    category = Category,
                    paid = IsPaid

                };

                var response = await _adminEndpoints.PostExpenseToUser(content);
                if (response == true)
                {
                    TryClose();
                }        

        }

        private int CalculateBrutto(int netto, int vat)
        {
            float floated = vat;
            float percet = floated / 100;
            int calculation = (int)(netto * percet);
            int result = calculation + netto;
            return result;
        }
    }
}
