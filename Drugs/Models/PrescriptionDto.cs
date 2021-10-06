using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Drugs.Models
{
    public class PrescriptionDto
    {
        public int Id { get; private set; } = 0;
        public string UserId { get; set; }
        public int Insurance_policy_number { get; set; }
        public string Insurance_Provider { get; set; }
        public DateTime Prescription_Date { get; set; }
        public int DrugId { get; set; }
        //[ForeignKey("Drug_Id")]
        //public virtual DrugDto Drug { get; set; }
        public string Doctor { get; set; }
    }
}
