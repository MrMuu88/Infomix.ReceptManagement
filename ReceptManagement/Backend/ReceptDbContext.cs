using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Backend
{
    public class ReceptDbContext : DbContext
    {
        public DbSet<SampleTable> SampleTables { get; set; }
        public DbSet<SampleTableElement> SampleTableElements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the database provider and connection string
            optionsBuilder.UseSqlServer("YourConnectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SampleTable>()
                .HasMany(st => st.SampleTableElements)
                .WithOne(ste => ste.SampleTable)
                .HasForeignKey(ste => ste.SampleTableId);
        }
    }
}
