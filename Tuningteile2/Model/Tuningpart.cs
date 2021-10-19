using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuningteile2.Model
{
    public class Tuningpart
    {
        public int TuningpartID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool Avaliability { get; set; }
        public Category Category { get; set; }
        public List<ModellTuningpart> ModellTuningparts { get; set; }
    }
}
