using Microsoft.EntityFrameworkCore;
using Pharmacy.Services.SubscriptionAPI.Models;
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
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
