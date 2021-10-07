using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drugs.Models
{
    public class AdhokRefillDto
    {

        public int Id { get; set; }
        public string UserID { get; set; }
        public int Subscription_ID { get; set; }
        public int Drug_ID { get; set; }
        public string Drug_Name { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public string RefillOccurance { get; set; }
        public bool IsPayment { get; set; } = false;
    }
}
