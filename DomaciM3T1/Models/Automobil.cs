using System.ComponentModel.DataAnnotations;

namespace DomaciM3T1.Models
{
    public class Automobil
    {
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int GodinaProizvodnje { get; set; }
        public int Kubikaza { get; set; }
        public string Boja { get; set; }
        public Proizvodjac Proizvodjac { get; set; }
        public int ProizvodjacId { get; set; }
        public Salon Salon { get; set; }
        public int SalonId { get; set; }
    }
}
