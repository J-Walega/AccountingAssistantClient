using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAssistantClient.Models
{
    public class Payment
    {
        public int User_id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Value { get; set; }
    }
}
