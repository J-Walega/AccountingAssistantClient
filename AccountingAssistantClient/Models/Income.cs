using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAssistantClient.Models
{
    public class Income
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public string Number { get; set; }
        public string Date_issue { get; set; }
        public string Buyer { get; set; }
        public long Nip { get; set; }
        public string Name { get; set; }
        public int Netto { get; set; }
        public int Vat { get; set; }
        public int Brutto { get; set; }
        public string Category { get; set; }
        public bool Paid { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
