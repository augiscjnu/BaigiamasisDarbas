using KnyguNuoma.Core.Modeliai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnyguNuoma.Core.Contracts
{
    public interface IElektroniniuKnyguRepozitorija
    {
        Task<bool> PridėtiKnygą(ElektroninėKnyga knyga);
        Task<ElektroninėKnyga> GautiKnygąPagalId(int id);
        Task<List<ElektroninėKnyga>> GautiVisasKnygas();
        Task<IEnumerable<Knyga>> GautiVisasKnygasPagalKategorija(string kategorija);
    }
}
