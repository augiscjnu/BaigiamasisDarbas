using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnyguNuoma.Core.Modeliai
{
    public class PopierinėKnyga : Knyga
    {
        public int KopijųKiekis { get; set; }
        public string ISBN { get; set; }
    }
}
