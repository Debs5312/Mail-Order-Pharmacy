using Microsoft.EntityFrameworkCore;
using Pharmacy.Services.RefillAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.SubscriptionAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AdhokRefill> AdhokRefills { get; set; }
        public DbSet<RefillStatus> RefillStatuses { get; set; }
    }
}
