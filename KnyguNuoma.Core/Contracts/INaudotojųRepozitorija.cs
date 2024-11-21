using KnyguNuoma.Core.Modeliai;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnyguNuoma.Core.Contracts
{
    public interface INaudotojųRepozitorija
    {
        List<Naudotojas> GautiVisus();
        Naudotojas? GautiPagalId(int id);
        Task<bool> PridėtiNaudotoją(Naudotojas naudotojas);  // Pridėti metodą
        Task<bool> IštrintiNaudotoją(int id);  // Pridėti metodą
    }
}
