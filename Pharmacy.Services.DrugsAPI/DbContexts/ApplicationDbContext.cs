using Microsoft.EntityFrameworkCore;
using Pharmacy.Services.DrugsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Services.DrugsAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<DrugDispatch> DrugDispatches { get; set; }
    }
}
