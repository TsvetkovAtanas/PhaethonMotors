﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhaethonMotors_Backend.Data;

#nullable disable

namespace PhaethonMotors_Backend.Migrations
{
    [DbContext(typeof(PhaethonDbContext))]
    [Migration("20250206152025_independentCustomizations")]
    partial class independentCustomizations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PhaethonMotors_Backend.Models.CarModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Acceleration")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CarImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CargoSpace")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DriveType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuelType1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuelType2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Horsepower")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatingCapacity")
                        .HasColumnType("int");

                    b.Property<decimal>("TopSpeed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Torque")
                        .HasColumnType("int");

                    b.Property<string>("Transmission")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("PhaethonMotors_Backend.Models.ColorOption", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CarModelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HexCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.ToTable("ColorOptions");
                });

            modelBuilder.Entity("PhaethonMotors_Backend.Models.FeatureOption", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CarModelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.ToTable("FeatureOptions");
                });

            modelBuilder.Entity("PhaethonMotors_Backend.Models.InteriorOption", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CarModelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.ToTable("InteriorOptions");
                });

            modelBuilder.Entity("PhaethonMotors_Backend.Models.TrimOption", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CarModelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("HorsepowerIncrease")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceIncrease")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Suspension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.ToTable("TrimOptions");
                });

            modelBuilder.Entity("PhaethonMotors_Backend.Models.WheelOption", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CarModelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.ToTable("WheelOptions");
                });

            modelBuilder.Entity("PhaethonMotors_Backend.Models.ColorOption", b =>
                {
                    b.HasOne("PhaethonMotors_Backend.Models.CarModel", null)
                        .WithMany("Colors")
                        .HasForeignKey("CarModelId");
                });

            modelBuilder.Entity("PhaethonMotors_Backend.Models.FeatureOption", b =>
                {
                    b.HasOne("PhaethonMotors_Backend.Models.CarModel", null)
                        .WithMany("Features")
                        .HasForeignKey("CarModelId");
                });

            modelBuilder.Entity("PhaethonMotors_Backend.Models.InteriorOption", b =>
                {
                    b.HasOne("PhaethonMotors_Backend.Models.CarModel", null)
                        .WithMany("Interiors")
                        .HasForeignKey("CarModelId");
                });

            modelBuilder.Entity("PhaethonMotors_Backend.Models.TrimOption", b =>
                {
                    b.HasOne("PhaethonMotors_Backend.Models.CarModel", null)
                        .WithMany("Trims")
                        .HasForeignKey("CarModelId");
                });

            modelBuilder.Entity("PhaethonMotors_Backend.Models.WheelOption", b =>
                {
                    b.HasOne("PhaethonMotors_Backend.Models.CarModel", null)
                        .WithMany("Wheels")
                        .HasForeignKey("CarModelId");
                });

            modelBuilder.Entity("PhaethonMotors_Backend.Models.CarModel", b =>
                {
                    b.Navigation("Colors");

                    b.Navigation("Features");

                    b.Navigation("Interiors");

                    b.Navigation("Trims");

                    b.Navigation("Wheels");
                });
#pragma warning restore 612, 618
        }
    }
}
