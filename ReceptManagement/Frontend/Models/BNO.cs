using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class BNO
    {
        public int BNOId { get; set; }

        public string BNOKod { get; set; }

        public string BetegsegNeve { get; set; }

        //public ICollection<Recept> Receptek { get; set; }
    }
}
