using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.RefillAPI.Models
{
    public class RefillStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int AdhocRefillId { get; set; }
        [Required]
        public string UserId { get; set; }
        public string DrugName { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        [Required]
        public bool PaymentStatus { get; set; }
    }
}
