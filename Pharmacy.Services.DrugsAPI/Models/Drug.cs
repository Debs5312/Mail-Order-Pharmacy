using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.DrugsAPI.Models
{
    public class Drug
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Mfgdate { get; set; }
        public DateTime ExpiryDate { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double PricePerPackage { get; set; }
        [Required]
        public int UnitInPackage { get; set; }
    }
}
