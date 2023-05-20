﻿// <auto-generated />
using Backend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(ReceptDbContext))]
    partial class ReceptDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend.Models.SampleTable", b =>
                {
                    b.Property<int>("SampleTableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SampleTableId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SampleTableId");

                    b.ToTable("SampleTables");
                });

            modelBuilder.Entity("Backend.Models.SampleTableElement", b =>
                {
                    b.Property<int>("SampleTableElementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SampleTableElementId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SampleTableId")
                        .HasColumnType("int");

                    b.HasKey("SampleTableElementId");

                    b.HasIndex("SampleTableId");

                    b.ToTable("SampleTableElements");
                });

            modelBuilder.Entity("Backend.Models.SampleTableElement", b =>
                {
                    b.HasOne("Backend.Models.SampleTable", "SampleTable")
                        .WithMany("SampleTableElements")
                        .HasForeignKey("SampleTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SampleTable");
                });

            modelBuilder.Entity("Backend.Models.SampleTable", b =>
                {
                    b.Navigation("SampleTableElements");
                });
#pragma warning restore 612, 618
        }
    }
}
