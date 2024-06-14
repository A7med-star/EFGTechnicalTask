using Microsoft.EntityFrameworkCore;
using System;
using TechnicalTask.Models;

namespace TechnicalTask.Data
{
    public class taskDbContext:DbContext
    {
        public DbSet<executionsModel> Executions { get; set;}
        public DbSet<invoicesModel> Invoices { get; set;}
        public DbSet<ordersModel> Orders { get; set;}

        public taskDbContext(DbContextOptions<taskDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the foreign key relationships
            modelBuilder.Entity<executionsModel>()
                .HasOne(e => e.Order)
                .WithMany(o => o.Executions)
                .HasForeignKey(e => e.orderID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<executionsModel>()
                .HasOne(e => e.Invoice)
                .WithMany(i => i.Executions)
                .HasForeignKey(e => e.invoiceID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<invoicesModel>()
                .HasOne(i => i.Order)
                .WithMany(o => o.Invoices)
                .HasForeignKey(i => i.orderID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
