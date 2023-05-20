using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class Paciens
    {
        public int PaciensId { get; set; }

        public string Nev { get; set; }

        public string Cim { get; set; }

        public DateTime Szuletesnap { get; set; }

        public string TAJ { get; set; }

        //public ICollection<Recept> Receptek { get; set; }
    }
}
