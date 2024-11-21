using KnyguNuoma.Core.Modeliai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnyguNuoma.Core.Contracts
{
    public interface IPopieriniuKnyguRepozitorija
    {
        Task<bool> PridėtiKnygą(PopierinėKnyga knyga);
        Task<PopierinėKnyga> GautiKnygąPagalId(int id);
        Task<List<PopierinėKnyga>> GautiVisasKnygas();
        Task<IEnumerable<Knyga>> GautiVisasKnygasPagalKategorija(string kategorija);
    }
}
