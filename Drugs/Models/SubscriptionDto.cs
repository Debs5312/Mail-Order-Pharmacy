using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Drugs.Models
{
    public class SubscriptionDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Member_Id { get; set; }
        [ForeignKey("Member_Id")]
        public virtual PrescriptionDto Prescription { get; set; }
        public int Drug_ID { get; set; }
        [ForeignKey("Drug_ID")]
        public virtual DrugDto Drug { get; set; }
        public string Location { get; set; }
        public DateTime Subscription_Date { get; set; }
        public string Refill_Occurrence { get; set; }
    }
}
