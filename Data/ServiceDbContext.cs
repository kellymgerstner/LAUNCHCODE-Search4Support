using LAUNCHCODE_Search4Support.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAUNCHCODE_Search4Support.Data
{
    public class ServiceDbContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ServiceCategory> Categories { get; set; }

        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Service>();
        }
    }
}
