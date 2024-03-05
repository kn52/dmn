﻿// <auto-generated />
using System;
using MagicVillaAPI.EntityContext.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVillaAPI.Migrations
{
    [DbContext(typeof(CommonDBContext))]
    [Migration("20240302211321_nunalble")]
    partial class nunalble
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MagicVillaAPI.Models.DAO.Villa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Amenity")
                        .HasColumnType("longtext");

                    b.Property<string>("CreatedDateTime")
                        .HasColumnType("longtext");

                    b.Property<string>("Details")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("Occupancy")
                        .HasColumnType("int");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<int?>("Sqft")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedDateTime")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Villa");
                });

            modelBuilder.Entity("MagicVillaAPI.Models.DAO.VillaNumber", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CreatedDateTime")
                        .HasColumnType("longtext");

                    b.Property<string>("SpecialDetails")
                        .HasColumnType("longtext");

                    b.Property<string>("UpdatedDateTime")
                        .HasColumnType("longtext");

                    b.Property<Guid>("VillaId")
                        .HasColumnType("char(36)");

                    b.Property<int>("VillaNo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VillaId");

                    b.ToTable("villa_numbers");
                });

            modelBuilder.Entity("MagicVillaAPI.Models.DAO.VillaNumber", b =>
                {
                    b.HasOne("MagicVillaAPI.Models.DAO.Villa", "Villa")
                        .WithMany()
                        .HasForeignKey("VillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Villa");
                });
#pragma warning restore 612, 618
        }
    }
}