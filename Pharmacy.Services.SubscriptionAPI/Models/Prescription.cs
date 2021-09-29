using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.SubscriptionAPI.Models
{
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string  UserId { get; set; }
        [Required]
        public int Insurance_policy_number { get; set; }
        [Required]
        public string Insurance_Provider { get; set; }
        [Required]
        public DateTime Prescription_Date { get; set; }
        public int DrugId { get; set; }
        [ForeignKey("Drug_Id")]
        public Drug Drug { get; set; }
        public string Doctor { get; set; }

    }
}
