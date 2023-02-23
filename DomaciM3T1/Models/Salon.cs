using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomaciM3T1.Models
{
    public class Salon
    {
        public int Id { get; set; }
        [Required]
        public int PIB { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string Drzava { get; set; }
        public string Grad { get; set; }
        public string Adresa { get; set; }
        public ICollection<Automobil> Automobils { get; set; }
        public ICollection<Proizvodjac> Proizvodjacs { get; set; }
    }
}
