using System;

namespace AccountingAssistantClient.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public string Number { get; set; }
        public string Date_issue { get; set; }
        public string Seller { get; set; }
        public long Nip { get; set; }
        public string Name { get; set; }
        public int Netto { get; set; }
        public int Vat { get; set; }
        public int Brutto { get; set; }
        public string Category { get; set; }
        public bool Paid { get; set; }
    }
}
