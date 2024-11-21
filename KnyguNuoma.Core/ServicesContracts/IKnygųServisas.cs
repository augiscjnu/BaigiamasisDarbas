using KnyguNuoma.Core.Modeliai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnyguNuoma.Core.ServicesContracts
{
    public interface IKnygųServisas
    {
        List<Knyga> GautiVisasKnygas();
        Knyga? GautiKnygaPagalId(int id);
        void PridetiKnyga(Knyga knyga);
        void PašalintiKnyga(int id);
        List<Knyga> IeškotiPagalKategoriją(string kategorija);
        void AtnaujintiKnyga(Knyga knyga);
    }
}
