using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuningteile2.Model
{
    public class ModellTuningpart
    {
        public int ModellTuningpartID { get; set; }
        public Modell Modell { get; set; }
        public Tuningpart Tuningpart { get; set; }
    }
}
