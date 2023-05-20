using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class BNO
    {
        public int BNOId { get; set; }

        [StringLength(5)]
        public string BNOKod { get; set; }

        [StringLength(50)]
        public string BetegsegNeve { get; set; }

        public ICollection<Recept> Receptek { get; set; }
    }
}
