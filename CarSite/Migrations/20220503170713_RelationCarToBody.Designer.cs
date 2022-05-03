﻿// <auto-generated />
using System;
using CarSite.DBAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarSite.Migrations
{
    [DbContext(typeof(CarsDbContext))]
    [Migration("20220503170713_RelationCarToBody")]
    partial class RelationCarToBody
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.3.22175.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarSite.DBAL.Entity.Body", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Body");
                });

            modelBuilder.Entity("CarSite.DBAL.Entity.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("CarSite.DBAL.Entity.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BodyId")
                        .HasColumnType("int");

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("SeatsCount")
                        .HasColumnType("tinyint");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BodyId");

                    b.HasIndex("BrandId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("CarSite.DBAL.Entity.Car", b =>
                {
                    b.HasOne("CarSite.DBAL.Entity.Body", "Body")
                        .WithMany()
                        .HasForeignKey("BodyId");

                    b.HasOne("CarSite.DBAL.Entity.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.Navigation("Body");

                    b.Navigation("Brand");
                });
#pragma warning restore 612, 618
        }
    }
}
