﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesWebApp.Models;

namespace SalesWebApp.Migrations
{
    [DbContext(typeof(SalesWebAppContext))]
    [Migration("20190226162950_OtherEntities")]
    partial class OtherEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SalesWebApp.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("SalesWebApp.Models.SalesRecord", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("amount");

                    b.Property<DateTime>("date");

                    b.Property<int?>("sellerid");

                    b.Property<int>("status");

                    b.HasKey("id");

                    b.HasIndex("sellerid");

                    b.ToTable("SalesRecord");
                });

            modelBuilder.Entity("SalesWebApp.Models.Seller", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("baseSalary");

                    b.Property<DateTime>("birthDate");

                    b.Property<int?>("departmentId");

                    b.Property<string>("email");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.HasIndex("departmentId");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("SalesWebApp.Models.SalesRecord", b =>
                {
                    b.HasOne("SalesWebApp.Models.Seller", "seller")
                        .WithMany("salesRecord")
                        .HasForeignKey("sellerid");
                });

            modelBuilder.Entity("SalesWebApp.Models.Seller", b =>
                {
                    b.HasOne("SalesWebApp.Models.Department", "department")
                        .WithMany("Sellers")
                        .HasForeignKey("departmentId");
                });
#pragma warning restore 612, 618
        }
    }
}
