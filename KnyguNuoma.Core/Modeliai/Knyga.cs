using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnyguNuoma.Core.Modeliai
{
    public abstract class Knyga
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; } // Title
        public string Autorius { get; set; } // Author
        public string Kategorija { get; set; } // Category
        public decimal NuomosKaina { get; set; } // Rental Price
        public DateTime SukurimoData { get; set; } // Creation Date
        public string Tipas { get; set; } // Type (Physical or E-book)

        // Additional properties in derived classes will be specific
    }





}
