using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomaciM3T1.Models
{
    public class Proizvodjac
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string Drzava { get; set; }
        public string Grad { get; set; }
        public Salon Salon { get; set; }
        public int SalonId { get; set; }
        public ICollection<Automobil> Automobils { get; set; }
    }
}
