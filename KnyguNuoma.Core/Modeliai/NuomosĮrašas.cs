using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnyguNuoma.Core.Modeliai
{
    public class NuomosĮrašas : BaseEntity
    {
        public int KnygosId { get; set; }
        public int NaudotojoId { get; set; }
        public DateTime NuomosPradžiosData { get; set; }
        public DateTime? NuomosPabaigosData { get; set; }
    }
}
