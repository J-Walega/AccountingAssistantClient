using System;
using System.Collections.Generic;

namespace AccountingAssistantClient.Models
{
    public class Invoice
    {
        public Invoice()
        {
            DateOfInvoice = DateTime.UtcNow;
        }

        public string Buyer { get; set; }
        public string Seller { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime DateOfInvoice { get; set; }
        public Dictionary<string, double> MerchandiseAndPrice { get; set; }
        public int Vat { get; set; }
    }
}
