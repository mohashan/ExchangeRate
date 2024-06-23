﻿// <auto-generated />
using System;
using ExchangeRate.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExchangeRate.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240623142100_remove_row_version")]
    partial class remove_row_version
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExchangeRate.Domain.ExchangeRates.ExchangeRate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime?>("LastUpdateOnUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_update_on_utc");

                    b.Property<string>("LastUpdateSource")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("last_update_source");

                    b.Property<string>("Pair")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)")
                        .HasColumnName("pair");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("rate");

                    b.HasKey("Id")
                        .HasName("pk_exchange_rate");

                    b.ToTable("ExchangeRate", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}