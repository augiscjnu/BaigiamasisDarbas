using KnyguNuoma.Core.Contracts;
using KnyguNuoma.Core.Modeliai;
using System.Collections.Generic;
using System.Threading.Tasks;

/*namespace KnyguNuoma.Core.Services
{
    public class NuomosPaslaugos : INuomosPaslaugos
    {
        private readonly INuomosRepozitorija _nuomosRepozitorija;

        public NuomosPaslaugos(INuomosRepozitorija nuomosRepozitorija)
        {
            _nuomosRepozitorija = nuomosRepozitorija;
        }

        // Pradėti nuomą
        public async Task PradetiNuomą(int knygosId, int vartotojoId)
        {
            // Papildoma logika (pvz., patikrinimai ar knyga yra laisva ir pan.)
            await _nuomosRepozitorija.PradetiNuomą(knygosId, vartotojoId);
        }

        // Užbaigti nuomą
        public async Task UzbiegtiNuomą(int nuomosId)
        {
            // Galima įdėti papildomą logiką, pvz., patikrinti ar nuoma tikrai aktyvi
            await _nuomosRepozitorija.UzbiegtiNuomą(nuomosId);
        }

        // Gauti aktyvią nuomą pagal vartotojo Id
        public async Task<NuomosĮrašas> GautiAktyviąNuomą(int vartotojoId)
        {
            // Gauti aktyvią nuomą
            return await _nuomosRepozitorija.GautiAktyviąNuomą(vartotojoId);
        }

        // Gauti nuomos istoriją pagal vartotojo Id
        public async Task<List<NuomosĮrašas>> GautiNuomosIstoriją(int vartotojoId)
        {
            // Gauti visą nuomos istoriją
            return await _nuomosRepozitorija.GautiNuomosIstoriją(vartotojoId);
        }

        // Gauti klientus, kurie nuomojo konkrečią knygą
        public async Task<List<Naudotojas>> GautiKlientusPagalKnygą(int knygosId)
        {
            // Gauti klientus pagal knygą
            return await _nuomosRepozitorija.GautiKlientusPagalKnygą(knygosId);
        }
    }
}*/
