using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Recept
    {
        public int ReceptId { get; set; }

        public DateTime ReceptKiallitasDatuma { get; set; }

        public DateTime ReceptSzovege { get; set; }

        public bool AltalanosJogcimmel { get; set; }

        public bool Kozgyogyellatottnak { get; set; }

        public bool EURendelkezessel { get; set; }

        public bool EUTeritesKotelesAronRendelve { get; set; }

        public bool TeljesAronRendelve { get; set; }

        public bool Helyettesitheto { get; set; }

        public int PaciensId { get; set; }
        public Paciens Paciens { get; set; }

        public int BNOId { get; set; }
        public BNO BNO { get; set; }
    }
}
