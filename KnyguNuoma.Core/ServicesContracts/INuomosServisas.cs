using KnyguNuoma.Core.Modeliai;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnyguNuoma.Core.Contracts
{
    public interface INuomosPaslaugos
    {
        Task PradetiNuomą(int knygosId, int vartotojoId);
        Task UzbiegtiNuomą(int nuomosId);
        Task<NuomosĮrašas> GautiAktyviąNuomą(int vartotojoId);
        Task<List<NuomosĮrašas>> GautiNuomosIstoriją(int vartotojoId);
        Task<List<Naudotojas>> GautiKlientusPagalKnygą(int knygosId);
    }
}
