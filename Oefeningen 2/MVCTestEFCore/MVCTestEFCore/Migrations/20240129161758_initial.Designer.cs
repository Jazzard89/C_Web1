﻿// <auto-generated />
using MVCTestEFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCTestEFCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240129161758_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MVCTestEFCore.Models.FirstTable", b =>
                {
                    b.Property<int>("FirstTableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FirstTableId"), 1L, 1);

                    b.Property<string>("TextColumn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FirstTableId");

                    b.ToTable("FirstTable");
                });
#pragma warning restore 612, 618
        }
    }
}
