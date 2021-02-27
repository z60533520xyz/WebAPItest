using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPItest.Models;

namespace WebAPItest.Data
{
    public class WebAPItestContext : DbContext
    {
        public WebAPItestContext (DbContextOptions<WebAPItestContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPItest.Models.PayIdInformation> PayIdInformation { get; set; }
        public DbSet<WebAPItest.Models.BenIdInformation> BenIdInformation { get; set; }
        public DbSet<WebAPItest.Models.IdInformation> IdInformation { get; set; }
        public DbSet<WebAPItest.Models.Product> Product { get; set; }
        public DbSet<WebAPItest.Models.SendApiRequest> SendApiRequest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PayIdInformation>().ToTable("PayIdInformation");
            modelBuilder.Entity<BenIdInformation>().ToTable("BenIdInformation");
            modelBuilder.Entity<IdInformation>().ToTable("IdInformation");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<SendApiRequest>().ToTable("SendApiRequest");
        }
    }
}
