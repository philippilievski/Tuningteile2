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

        /// <summary>
        /// Gibt alle Modelle aus der Datenbank zurück
        /// </summary>
        /// <returns>Liste von Modellen</returns>
        public List<Modell> GetModells()
        {
            var modells = tuningteileContext.Modells
                .Include(m => m.Brand)
                .ToList();
            return modells;
        }

        /// <summary>
        /// Gibt alle Tuningteile aus der Datenbank zurück
        /// </summary>
        /// <returns>Liste von Tuningparts</returns>
        public List<Tuningpart> GetTuningparts()
        {
            var tuningparts = tuningteileContext.Tuningparts
                .Include(tp => tp.Category)
                .ToList();
            return tuningparts;
        }

        /// <summary>
        /// Gibt alle Modelle und Tuningteile zurück welche das gleiche Modell haben
        /// </summary>
        /// <param name="modell"></param>
        /// <returns>Liste von ModellTuningpart</returns>
        public List<ModellTuningpart> GetModellTuningparts(Modell modell)
        {
            var modelltuningparts = tuningteileContext.ModellTuningparts
                .Include(tp => tp.Modell)
                .Include(tp => tp.Tuningpart)
                .Where(tp => tp.Modell == modell)
                .ToList();
            return modelltuningparts;
        }

        /// <summary>
        /// Entfernt ein Tuningteil aus der Datenbank
        /// </summary>
        /// <param name="tuningpart"></param>
        public void RemoveTuningPart(Tuningpart tuningpart)
        {
            var modelltuningpart = tuningteileContext.ModellTuningparts
                .Include(tp => tp.Modell)
                .Include(tp => tp.Tuningpart)
                .Where(tp => tp.Tuningpart == tuningpart).ToList();

            foreach(var item in modelltuningpart)
            {
                tuningteileContext.Remove(item);
            }

            tuningteileContext.Remove(tuningpart);
            tuningteileContext.SaveChanges();
        }

        /// <summary>
        /// Gibt alle Kategorien zurück
        /// </summary>
        /// <returns>Liste von Kategorien</returns>
        public List<Category> GetCategories()
        {
            var categories = tuningteileContext.Categories
                .ToList();
            return categories;
        }

        /// <summary>
        /// Fügt der Datenbank ein Tuningteil hinzu
        /// </summary>
        /// <param name="tuningpart"></param>
        public void AddTuningpart(Tuningpart tuningpart)
        {
            tuningteileContext.Add(tuningpart);
            tuningteileContext.SaveChanges();
        }

        /// <summary>
        /// Updatet das als Parameter übergebene Tuningpart
        /// </summary>
        /// <param name="tuningpart"></param>
        public void UpdateTuningpart(Tuningpart tuningpart)
        {
            tuningteileContext.Update(tuningpart);
            tuningteileContext.SaveChanges();
        }

        /// <summary>
        /// Fügt der Datenbank ein Modell hinzu
        /// </summary>
        /// <param name="modell"></param>
        public void AddModell(Modell modell)
        {
            tuningteileContext.Add(modell);
            tuningteileContext.SaveChanges();
        }


        /// <summary>
        /// Fügt der Datenbank ein modelltuningpart hinzu
        /// </summary>
        /// <param name="modell"></param>
        /// <param name="tuningpart"></param>
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
