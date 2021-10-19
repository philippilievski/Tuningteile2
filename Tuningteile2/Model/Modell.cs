using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuningteile2.Model
{
    public class Modell
    {
        public int ModellID { get; set; }
        public string Title { get; set; }
        public int YearManufactured { get; set; }
        public List<ModellTuningpart> ModellTuningparts { get; set; }
    }
}
