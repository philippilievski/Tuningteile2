﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tuningteile2;

namespace Tuningteile2.Migrations
{
    [DbContext(typeof(TuningteileContext))]
    [Migration("20211019114914_brand")]
    partial class brand
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tuningteile2.Model.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Tuningteile2.Model.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Tuningteile2.Model.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashPw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Tuningteile2.Model.Modell", b =>
                {
                    b.Property<int>("ModellID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrandID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearManufactured")
                        .HasColumnType("int");

                    b.HasKey("ModellID");

                    b.HasIndex("BrandID");

                    b.ToTable("Modells");
                });

            modelBuilder.Entity("Tuningteile2.Model.ModellTuningpart", b =>
                {
                    b.Property<int>("ModellTuningpartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ModellID")
                        .HasColumnType("int");

                    b.Property<int?>("TuningpartID")
                        .HasColumnType("int");

                    b.HasKey("ModellTuningpartID");

                    b.HasIndex("ModellID");

                    b.HasIndex("TuningpartID");

                    b.ToTable("ModellTuningparts");
                });

            modelBuilder.Entity("Tuningteile2.Model.Tuningpart", b =>
                {
                    b.Property<int>("TuningpartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Avaliability")
                        .HasColumnType("bit");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TuningpartID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Tuningparts");
                });

            modelBuilder.Entity("Tuningteile2.Model.Modell", b =>
                {
                    b.HasOne("Tuningteile2.Model.Brand", "Brand")
                        .WithMany("Modells")
                        .HasForeignKey("BrandID");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Tuningteile2.Model.ModellTuningpart", b =>
                {
                    b.HasOne("Tuningteile2.Model.Modell", "Modell")
                        .WithMany("ModellTuningparts")
                        .HasForeignKey("ModellID");

                    b.HasOne("Tuningteile2.Model.Tuningpart", "Tuningpart")
                        .WithMany("ModellTuningparts")
                        .HasForeignKey("TuningpartID");

                    b.Navigation("Modell");

                    b.Navigation("Tuningpart");
                });

            modelBuilder.Entity("Tuningteile2.Model.Tuningpart", b =>
                {
                    b.HasOne("Tuningteile2.Model.Category", "Category")
                        .WithMany("Tuningparts")
                        .HasForeignKey("CategoryID");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Tuningteile2.Model.Brand", b =>
                {
                    b.Navigation("Modells");
                });

            modelBuilder.Entity("Tuningteile2.Model.Category", b =>
                {
                    b.Navigation("Tuningparts");
                });

            modelBuilder.Entity("Tuningteile2.Model.Modell", b =>
                {
                    b.Navigation("ModellTuningparts");
                });

            modelBuilder.Entity("Tuningteile2.Model.Tuningpart", b =>
                {
                    b.Navigation("ModellTuningparts");
                });
#pragma warning restore 612, 618
        }
    }
}
