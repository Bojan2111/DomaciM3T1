﻿// <auto-generated />
using DomaciM3T1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DomaciM3T1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomaciM3T1.Models.Automobil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Boja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GodinaProizvodnje")
                        .HasColumnType("int");

                    b.Property<int>("Kubikaza")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProizvodjacId")
                        .HasColumnType("int");

                    b.Property<int>("SalonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProizvodjacId");

                    b.HasIndex("SalonId");

                    b.ToTable("Automobils");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Boja = "Sarena",
                            GodinaProizvodnje = 2002,
                            Kubikaza = 1680,
                            Model = "Brmm",
                            ProizvodjacId = 2,
                            SalonId = 1
                        },
                        new
                        {
                            Id = 2,
                            Boja = "Crvena",
                            GodinaProizvodnje = 2003,
                            Kubikaza = 1780,
                            Model = "Vrmm",
                            ProizvodjacId = 3,
                            SalonId = 2
                        },
                        new
                        {
                            Id = 3,
                            Boja = "Zelena",
                            GodinaProizvodnje = 2004,
                            Kubikaza = 1880,
                            Model = "Kvrc",
                            ProizvodjacId = 3,
                            SalonId = 2
                        },
                        new
                        {
                            Id = 4,
                            Boja = "Purple",
                            GodinaProizvodnje = 2005,
                            Kubikaza = 1980,
                            Model = "Brrr",
                            ProizvodjacId = 1,
                            SalonId = 3
                        });
                });

            modelBuilder.Entity("DomaciM3T1.Models.Proizvodjac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Drzava")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalonId");

                    b.ToTable("Proizvodjacs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Drzava = "Neka drzava",
                            Grad = "Neki grad",
                            Naziv = "NajAuto",
                            SalonId = 3
                        },
                        new
                        {
                            Id = 2,
                            Drzava = "Nova drzava",
                            Grad = "Novi grad",
                            Naziv = "NovAuto",
                            SalonId = 1
                        },
                        new
                        {
                            Id = 3,
                            Drzava = "Moja drzava",
                            Grad = "Prvi grad",
                            Naziv = "MojAuto",
                            SalonId = 2
                        });
                });

            modelBuilder.Entity("DomaciM3T1.Models.Salon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Drzava")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PIB")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Salon");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adresa = "Neka Adresa 1",
                            Drzava = "Neka drzava",
                            Grad = "Neki grad",
                            Naziv = "Salon1",
                            PIB = 1234
                        },
                        new
                        {
                            Id = 2,
                            Adresa = "Neka Adresa 2",
                            Drzava = "Nova drzava",
                            Grad = "Novi grad",
                            Naziv = "Salon2",
                            PIB = 1235
                        },
                        new
                        {
                            Id = 3,
                            Adresa = "Neka Adresa 3",
                            Drzava = "Moja drzava",
                            Grad = "Prvi grad",
                            Naziv = "Salon3",
                            PIB = 1236
                        });
                });

            modelBuilder.Entity("DomaciM3T1.Models.Automobil", b =>
                {
                    b.HasOne("DomaciM3T1.Models.Proizvodjac", "Proizvodjac")
                        .WithMany("Automobils")
                        .HasForeignKey("ProizvodjacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomaciM3T1.Models.Salon", "Salon")
                        .WithMany("Automobils")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proizvodjac");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("DomaciM3T1.Models.Proizvodjac", b =>
                {
                    b.HasOne("DomaciM3T1.Models.Salon", "Salon")
                        .WithMany("Proizvodjacs")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("DomaciM3T1.Models.Proizvodjac", b =>
                {
                    b.Navigation("Automobils");
                });

            modelBuilder.Entity("DomaciM3T1.Models.Salon", b =>
                {
                    b.Navigation("Automobils");

                    b.Navigation("Proizvodjacs");
                });
#pragma warning restore 612, 618
        }
    }
}
