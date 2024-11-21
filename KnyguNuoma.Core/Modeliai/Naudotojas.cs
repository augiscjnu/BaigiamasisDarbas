using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnyguNuoma.Core.Modeliai
{
    public class Naudotojas : BaseEntity
    {
        public string Vardas { get; set; }
        public string ElPaštas { get; set; }
    }
}
