using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.SubscriptionAPI.Models.Dto
{
    public class DrugDto
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime Mfgdate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public string Location { get; set; }

        public int Quantity { get; set; }
 
        public double PricePerPackage { get; set; }
   
        public int UnitInPackage { get; set; }
    }
}
