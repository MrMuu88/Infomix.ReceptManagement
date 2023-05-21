using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Configuration;

// Package Manager:
// Install-Package Microsoft.EntityFrameworkCore.Tools

// CMD:
// cd c:\--CODE--\INFOMIX\ReceptManagement\Backend
// dotnet tool install --global dotnet-ef
// dotnet ef migrations add InitialCreate
// dotnet ef database update

// I used MS SQL EXPRESS 2022. Commited a recent .bak, .mdf, .ldf files
// TODO: I did not use "EnsureCreated".
// You have to create an empty database.
// You can find the connectionstring in appsettings.json, and appsettings.Development.json
// I accidently used "api/PrescriptionApi" instead of "api/Prescription"

namespace Backend
{
    public class ReceptDbContext : DbContext
    {
        public DbSet<Recept> Receptek { get; set; }
        public DbSet<Paciens> Paciensek { get; set; }
        public DbSet<BNO> BNOk { get; set; }

        public ReceptDbContext(DbContextOptions<ReceptDbContext> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            // Configure the database provider and connection string
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
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
