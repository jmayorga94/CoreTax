using CoreTax.Domain.Entities.Impuestos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTax.Infrastructure.Data
{
    public class CoreTaxDbContext : DbContext
    {
        public CoreTaxDbContext(DbContextOptions options) : base(options)
        {
 
        }
        public DbSet<Impuesto> Impuestos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
