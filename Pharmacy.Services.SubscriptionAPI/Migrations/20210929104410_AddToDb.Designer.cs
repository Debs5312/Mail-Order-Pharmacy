﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pharmacy.Services.SubscriptionAPI.DbContexts;

namespace Pharmacy.Services.SubscriptionAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210929104410_AddToDb")]
    partial class AddToDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pharmacy.Services.SubscriptionAPI.Models.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Doctor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrugId")
                        .HasColumnType("int");

                    b.Property<string>("Insurance_Provider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Insurance_policy_number")
                        .HasColumnType("int");

                    b.Property<DateTime>("Prescription_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("Pharmacy.Services.SubscriptionAPI.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Drug_ID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Prescription_Id")
                        .HasColumnType("int");

                    b.Property<string>("Refill_Occurrence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Subscription_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}