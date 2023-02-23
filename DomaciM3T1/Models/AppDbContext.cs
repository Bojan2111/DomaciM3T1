using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DomaciM3T1.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Automobil> Automobils { get; set; }
        public DbSet<Proizvodjac> Proizvodjacs { get; set; }
        public DbSet<Salon> Salon { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Automobil>().HasData(
                new Automobil { Id = 1, Model = "Brmm", GodinaProizvodnje = 2002, Kubikaza = 1680, Boja = "Sarena", SalonId = 1, ProizvodjacId = 2 },
                new Automobil { Id = 2, Model = "Vrmm", GodinaProizvodnje = 2003, Kubikaza = 1780, Boja = "Crvena", SalonId = 2, ProizvodjacId = 3 },
                new Automobil { Id = 3, Model = "Kvrc", GodinaProizvodnje = 2004, Kubikaza = 1880, Boja = "Zelena", SalonId = 2, ProizvodjacId = 3 },
                new Automobil { Id = 4, Model = "Brrr", GodinaProizvodnje = 2005, Kubikaza = 1980, Boja = "Purple", SalonId = 3, ProizvodjacId = 1 }
            );

            modelBuilder.Entity<Proizvodjac>().HasData(
                new Proizvodjac { Id = 1, Naziv = "NajAuto", Drzava = "Neka drzava", Grad = "Neki grad", SalonId = 3, Automobils = new List<Automobil>() },
                new Proizvodjac { Id = 2, Naziv = "NovAuto", Drzava = "Nova drzava", Grad = "Novi grad", SalonId = 1, Automobils = new List<Automobil>() },
                new Proizvodjac { Id = 3, Naziv = "MojAuto", Drzava = "Moja drzava", Grad = "Prvi grad", SalonId = 2, Automobils = new List<Automobil>() }
            );

            modelBuilder.Entity<Salon>().HasData(
                new Salon { Id = 1, PIB = 1234, Naziv = "Salon1", Drzava = "Neka drzava", Grad = "Neki grad", Adresa = "Neka Adresa 1", Proizvodjacs = new List<Proizvodjac>(), Automobils = new List<Automobil>() },
                new Salon { Id = 2, PIB = 1235, Naziv = "Salon2", Drzava = "Nova drzava", Grad = "Novi grad", Adresa = "Neka Adresa 2", Proizvodjacs = new List<Proizvodjac>(), Automobils = new List<Automobil>() },
                new Salon { Id = 3, PIB = 1236, Naziv = "Salon3", Drzava = "Moja drzava", Grad = "Prvi grad", Adresa = "Neka Adresa 3", Proizvodjacs = new List<Proizvodjac>(), Automobils = new List<Automobil>() }
            );

            modelBuilder.Entity<Salon>()
                .HasMany(s => s.Automobils)
                .WithOne(a => a.Salon)
                .HasForeignKey(a => a.SalonId);

            modelBuilder.Entity<Salon>()
                .HasMany(s => s.Proizvodjacs)
                .WithOne(p => p.Salon)
                .HasForeignKey(p => p.SalonId);

            modelBuilder.Entity<Proizvodjac>()
                .HasMany(p => p.Automobils)
                .WithOne(a => a.Proizvodjac)
                .HasForeignKey(a => a.ProizvodjacId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
