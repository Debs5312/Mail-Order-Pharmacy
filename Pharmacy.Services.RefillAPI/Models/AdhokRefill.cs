using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.RefillAPI.Models
{
    public class AdhokRefill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public int Subscription_ID { get; set; }
        [Required]
        public int Drug_ID { get; set; }
        public string Drug_Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string RefillOccurance { get; set; }
        [Required]
        public bool IsPayment { get; set; }

    }
}
