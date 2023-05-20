using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

// Packe Manager-ben:
// Install-Package Microsoft.EntityFrameworkCore.Tools
// CMD-ben:
// cd c:\--CODE--\INFOMIX\ReceptManagement\Backend
// dotnet tool install --global dotnet-ef
// dotnet ef migrations add InitialCreate
// dotnet ef database update

namespace Backend
{
    public class ReceptDbContext : DbContext
    {
        public DbSet<Recept> Receptek { get; set; }
        public DbSet<Paciens> Paciensek { get; set; }
        public DbSet<BNO> BNOk { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the database provider and connection string
            optionsBuilder.UseSqlServer("Server=AURELPC\\SQLEXPRESS;Database=infomix;User Id=infomix;Password=infomix;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciens>()
                .HasMany(p => p.Receptek)
                .WithOne(r => r.Paciens)
                .HasForeignKey(r => r.PaciensId);

            modelBuilder.Entity<BNO>()
                .HasMany(b => b.Receptek)
                .WithOne(r => r.BNO)
                .HasForeignKey(r => r.BNOId);
        }
    }
}
