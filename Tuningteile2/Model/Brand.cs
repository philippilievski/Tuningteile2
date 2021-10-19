using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuningteile2.Model
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string Title { get; set; }
        public List<Modell> Modells{ get; set; }
    }
}
