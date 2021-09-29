using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.SubscriptionAPI.Models
{
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Prescription_Id { get; set; }
        [Required]
        public int Drug_ID { get; set; }
        [Required]
        public string Location { get; set; }
        public DateTime Subscription_Date { get; set; }
        public string Refill_Occurrence { get; set; }

    }
}
