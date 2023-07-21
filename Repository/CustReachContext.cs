using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using TheChampions.Models;

namespace TheChampions.Repository
{
    public class CustReachContext : DbContext
    {
        public CustReachContext(DbContextOptions<CustReachContext> options) : base(options)
        {
            
        }

        public DbSet<CustomerReach> CustomerReach { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    //modelBuilder.Entity<Person>(e => e.Property(o => o.Age).HasColumnType("tinyint(1)").HasConversion<short>());
        //    modelBuilder.Entity<CustomerReach>(e => e.Property(o => o.Phone_Number).HasColumnType("int"));


        //}
    }
}
