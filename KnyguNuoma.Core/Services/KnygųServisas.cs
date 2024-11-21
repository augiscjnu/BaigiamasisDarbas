using KnyguNuoma.Core.Modeliai;
using KnyguNuoma.Core.Contracts;
using KnyguNuoma.Core.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KnyguNuoma.Core.Services
{
    public class KnygųServisas : IKnygųServisas
    {
        private readonly IKnygųServisas _repozitorija;

        // Konstruktoras, kuris įdeda repo (priklauso nuo DI)
        public KnygųServisas(IKnygųServisas repozitorija)
        {
            _repozitorija = repozitorija;
        }

        // Gauti visas knygas
        public List<Knyga> GautiVisasKnygas()
        {
            return _repozitorija.GautiVisasKnygas();
        }

        // Gauti knygą pagal ID
        public Knyga? GautiKnygaPagalId(int id)
        {
            var knyga = _repozitorija.GautiKnygaPagalId(id);
            if (knyga == null)
            {
                throw new InvalidOperationException($"Knyga su ID {id} nerasta.");
            }
            return knyga;
        }

        // Pridėti knygą
        public void PridetiKnyga(Knyga knyga)
        {
            // Galite pridėti papildomą logiką, pvz., patikrinti, ar knyga su tokiu pavadinimu jau egzistuoja.
            if (_repozitorija.GautiVisasKnygas().Any(k => k.Pavadinimas.Equals(knyga.Pavadinimas, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Knyga su tokiu pavadinimu jau egzistuoja.");
            }
            _repozitorija.PridetiKnyga(knyga);
        }

        // Pašalinti knygą pagal ID
        public void PašalintiKnyga(int id)
        {
            var knyga = _repozitorija.GautiKnygaPagalId(id);
            if (knyga == null)
            {
                throw new InvalidOperationException($"Knyga su ID {id} nerasta.");
            }
            _repozitorija.PašalintiKnyga(id);
        }

        // Ieškoti knygų pagal kategoriją
        public List<Knyga> IeškotiPagalKategoriją(string kategorija)
        {
            if (string.IsNullOrEmpty(kategorija))
            {
                throw new ArgumentException("Kategorija negali būti tuščia.");
            }

            var knygos = _repozitorija.IeškotiPagalKategoriją(kategorija);

            if (knygos.Count == 0)
            {
                throw new InvalidOperationException($"Knygos pagal kategoriją {kategorija} nerastos.");
            }

            return knygos;
        }

        public void AtnaujintiKnyga(Knyga knyga)
        {
            throw new NotImplementedException();
        }
    }
}
