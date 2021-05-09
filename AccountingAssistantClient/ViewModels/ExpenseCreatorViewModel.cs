using System.Text.RegularExpressions;
using System.Windows.Input;
using Caliburn.Micro;

namespace AccountingAssistantClient.ViewModels
{
    public class ExpenseCreatorViewModel : Screen
    {

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

        private double _netto;

        public double Netto
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

    }
}
