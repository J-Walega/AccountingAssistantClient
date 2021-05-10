using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAssistantClient.Models
{
    public class PatchExpenseRequest
    {
        public int expense_id { get; set; }
        public string number { get; set; }
        public string date_issue { get; set; }
        public string seller { get; set; }
        public long nip { get; set; }
        public string name { get; set; }
        public int netto { get; set; }
        public int vat { get; set; }
        public int brutto { get; set; }
        public string category { get; set; }
        public bool paid { get; set; }
    }
}
