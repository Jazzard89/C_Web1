﻿// <auto-generated />
using System;
using MVCSportStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCSportStore.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class StoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MVCSportStore.Models.Product", b =>
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

            modelBuilder.Entity("MVCSportStore.Models.Reseller", b =>
                {
                    b.Property<int>("ResellerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResellerId"), 1L, 1);

                    b.Property<string>("ContentManagementGuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResellerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResellerId");

                    b.ToTable("Resellers");
                });

            modelBuilder.Entity("MVCSportStore.Models.ResellerStock", b =>
                {
                    b.Property<int>("ResellerStockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResellerStockId"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("ResellerGuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResellerId")
                        .HasColumnType("int");

                    b.HasKey("ResellerStockId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ResellerId");

                    b.ToTable("ResellersStocks");
                });

            modelBuilder.Entity("MVCSportStore.Models.ResellerStock", b =>
                {
                    b.HasOne("MVCSportStore.Models.Product", "Product")
                        .WithMany("ResellerStocks")
                        .HasForeignKey("ProductId");

                    b.HasOne("MVCSportStore.Models.Reseller", "Reseller")
                        .WithMany("ResellerStocks")
                        .HasForeignKey("ResellerId");

                    b.Navigation("Product");

                    b.Navigation("Reseller");
                });

            modelBuilder.Entity("MVCSportStore.Models.Product", b =>
                {
                    b.Navigation("ResellerStocks");
                });

            modelBuilder.Entity("MVCSportStore.Models.Reseller", b =>
                {
                    b.Navigation("ResellerStocks");
                });
#pragma warning restore 612, 618
        }
    }
}
