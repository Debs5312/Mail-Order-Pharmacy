﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.SubscriptionAPI.Models.Dto
{
    public class DrugDispatchDto
    {
        public int Id { get; set; }
        public int DrugId { get; set; }
        [ForeignKey("DrugId")]
        public virtual DrugDto Drug { get; set; }
        public bool IsDispatched { get; set; }
        public DateTime Time { get; set; }
        public bool IsPayment { get; set; }
    }
}
