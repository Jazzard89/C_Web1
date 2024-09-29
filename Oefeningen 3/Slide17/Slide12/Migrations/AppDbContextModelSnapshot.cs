﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Slide12.Data;

#nullable disable

namespace Slide12.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Slide12.Models.Product", b =>
                {
                    b.Property<long?>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("ProductId"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Slide12.Models.Reseller", b =>
                {
                    b.Property<int>("ResellerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResellerId"), 1L, 1);

                    b.Property<string>("ContentManagementGuid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResellerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResellerId");

                    b.ToTable("Resellers");
                });

            modelBuilder.Entity("Slide12.Models.ResellerStock", b =>
                {
                    b.Property<int>("ResellerStockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResellerStockId"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<long?>("ProductId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<int>("ResellerId")
                        .HasColumnType("int");

                    b.HasKey("ResellerStockId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ResellerId");

                    b.ToTable("ResellerStocks");
                });

            modelBuilder.Entity("Slide12.Models.ResellerStock", b =>
                {
                    b.HasOne("Slide12.Models.Product", "Product")
                        .WithMany("Stocks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Slide12.Models.Reseller", "Reseller")
                        .WithMany("Stocks")
                        .HasForeignKey("ResellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Reseller");
                });

            modelBuilder.Entity("Slide12.Models.Product", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("Slide12.Models.Reseller", b =>
                {
                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
