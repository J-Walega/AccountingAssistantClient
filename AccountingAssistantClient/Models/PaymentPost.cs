using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAssistantClient.Models
{
    public class PaymentPost
    {
        public int user_id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public int value { get; set; }
    }
}
