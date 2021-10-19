using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuningteile2.Model;

namespace Tuningteile2.Logic
{
    class DataLogic
    {
        TuningteileContext tuningteileContext = new TuningteileContext();
        public List<Modell> GetModells()
        {
            var modells = tuningteileContext.Modells.ToList();
            return modells;
        }

        public List<Tuningpart> GetTuningparts()
        {
            var tuningparts = tuningteileContext.Tuningparts
                .Include(tp => tp.Category)
                .ToList();
            return tuningparts;
        }

        public List<ModellTuningpart> GetModellTuningparts(Modell modell)
        {
            var modelltuningparts = tuningteileContext.ModellTuningparts
                .Include(tp => tp.Modell)
                .Include(tp => tp.Tuningpart)
                .Where(tp => tp.Modell == modell)
                .ToList();
            return modelltuningparts;
        }

        public void RemoveTuningPart(Tuningpart tuningpart)
        {  
            tuningteileContext.Remove(tuningpart);
            tuningteileContext.SaveChanges();
        }
        public List<Category> GetCategories()
        {
            var categories = tuningteileContext.Categories
                .ToList();
            return categories;
        }

        public void AddTuningpart(Tuningpart tuningpart)
        {
            tuningteileContext.Add(tuningpart);
            tuningteileContext.SaveChanges();
        }

        public void UpdateTuningpart(Tuningpart tuningpart)
        {
            tuningteileContext.Update(tuningpart);
            tuningteileContext.SaveChanges();
        }
        public void AddModell(Modell modell)
        {
            tuningteileContext.Add(modell);
            tuningteileContext.SaveChanges();
        }

        public void AddCompatability(Modell modell, Tuningpart tuningpart)
        {
            ModellTuningpart modellTuningpart = new ModellTuningpart();
            modellTuningpart.Modell = modell;
            modellTuningpart.Tuningpart = tuningpart;

            tuningteileContext.Add(modellTuningpart);
            tuningteileContext.SaveChanges();
        }
    }
}
