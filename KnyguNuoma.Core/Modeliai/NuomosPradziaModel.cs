using System;

namespace KnyguNuoma.Core.Modeliai
{
    public class NuomosPradziaModel
    {
        public int KnygosId { get; set; }
        public int VartotojoId { get; set; }
        public DateTime? PradziosData { get; set; } // Neprivaloma, jei neperduodama, bus naudota dabartinė data
        public DateTime? PabaigosData { get; set; } // Neprivaloma, jei neperduodama, bus nustatyta pagal numatytąjį laikotarpį
    }
}
