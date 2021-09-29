using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.SubscriptionAPI.Models.Dto
{
    public class SubscriptionDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Prescription_Id { get; set; }
        [ForeignKey("Prescription_Id")]
        public virtual PrescriptionDto Prescription { get; set; }
        public int Drug_ID { get; set; }
        public string Location { get; set; }
        public DateTime Subscription_Date { get; set; }
        public string Refill_Occurrence { get; set; }
    }
}
