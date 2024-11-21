using KnyguNuoma.Core.Modeliai;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnyguNuoma.Core.Contracts
{
    public interface IKnyguRepozitorija
    {
        Task<bool> PridėtiKnygą(Knyga knyga);
        Task<List<Knyga>> GautiVisasKnygas();
        Task<List<Knyga>> GautiKnygasPagalKategoriją(string kategorija);
    }
}
