using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuningteile2.Model
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public List<Tuningpart> Tuningparts { get; set; }
    }
}
