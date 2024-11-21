using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnyguNuoma.Core.Modeliai
{
    public class ElektroninėKnyga : Knyga
    {
        public string FailoFormatas { get; set; }
        public double FailoDydisMB { get; set; }
    }
}
