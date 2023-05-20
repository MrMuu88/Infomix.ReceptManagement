using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Paciens
    {
        public int PaciensId { get; set; }

        [StringLength(50)]
        public string Nev { get; set; }

        [StringLength(50)]
        public string Cim { get; set; }

        public DateTime Szuletesnap { get; set; }

        [StringLength(50)]
        public string TAJ { get; set; }

        public ICollection<Recept> Receptek { get; set; }
    }
}
