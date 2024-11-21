using KnyguNuoma.Core.Modeliai;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnyguNuoma.Core.Contracts
{
    public interface INuomosRepozitorija
    {
        Task PradetiNuomą(int knygosId, int vartotojoId, DateTime? pradziosData = null, DateTime? pabaigosData = null);
        Task UzbiegtiNuomą(int nuomosId);
        Task<NuomosĮrašas> GautiAktyviaNuomą(int vartotojoId);
        Task<List<NuomosĮrašas>> GautiNuomosIstoriją(int vartotojoId);
        Task<List<Naudotojas>> GautiKlientusPagalKnygą(int knygosId);
        Task<List<NuomosĮrašas>> GautiVisasEsamasNuomas();
    }
}
