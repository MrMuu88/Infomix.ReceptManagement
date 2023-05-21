using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ResponseClasses
{
    public class PrescriptionResponse
    {
        public string PatientName { get; set; }
        public int PrescriptionId { get; set; }
        public int BNOId { get; set; }
        public DateTime PrescribedDate { get; set; }
        public string PrescriptionText { get; set; }
    }
}
