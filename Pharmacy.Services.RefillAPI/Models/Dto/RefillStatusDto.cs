using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.RefillAPI.Models.Dto
{
    public class RefillStatusDto
    {
        public int Id { get; set; }
        public int AdhocRefillId { get; set; }
        public string UserId { get; set; }
        public string DrugName { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
