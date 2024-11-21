using KnyguNuoma.Core.Contracts;
using KnyguNuoma.Core.Modeliai;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace KnyguNuoma.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NaudotojaiController : ControllerBase // Pakeista: turi būti ControllerBase, ne Controller
    {
        private readonly INaudotojųRepozitorija _naudotojųRepozitorija;
        private readonly ILogger<NaudotojaiController> _logger;

        // Konstruktoriumi įdedame priklausomybę, įskaitant loggerį
        public NaudotojaiController(INaudotojųRepozitorija naudotojųRepozitorija, ILogger<NaudotojaiController> logger)
        {
            _naudotojųRepozitorija = naudotojųRepozitorija;
            _logger = logger;
        }

        // Gauti visus naudotojus ir parodyti juos (API)
        [HttpGet]
        public ActionResult<List<Naudotojas>> Get()
        {
            _logger.LogInformation("Gauti visi naudotojai.");

            try
            {
                // Kviečiame repo metodą, kad gautume visus naudotojus
                List<Naudotojas> naudotojai = _naudotojųRepozitorija.GautiVisus();

                // Jeigu nėra naudotojų
                if (naudotojai.Count == 0)
                {
                    _logger.LogWarning("Naudotojų sąrašas yra tuščias.");
                }

                // Grąžiname naudotojus kaip JSON
                return Ok(naudotojai);  // Ok() automatiškai sugrąžins JSON atsakymą
            }
            catch (System.Exception ex)
            {
                // Jei įvyko klaida
                _logger.LogError(ex, "Klaida gavus visus naudotojus.");
                return StatusCode(500, "Įvyko klaida tvarkant duomenis.");
            }
        }

        // Gauti naudotoją pagal ID ir parodyti detales (API)
        [HttpGet("{id}")]
        public ActionResult<Naudotojas> Get(int id)
        {
            _logger.LogInformation("Gauti naudotojo detales pagal ID: {UserId}", id);

            try
            {
                // Kviečiame repo metodą, kad gautume naudotoją pagal ID
                Naudotojas? naudotojas = _naudotojųRepozitorija.GautiPagalId(id);

                if (naudotojas == null)
                {
                    // Jei naudotojas nerastas, grąžiname 404 klaidą
                    _logger.LogWarning("Naudotojas su ID {UserId} nerastas.", id);
                    return NotFound();
                }

                // Grąžiname naudotojo duomenis kaip JSON
                return Ok(naudotojas); // Ok() automatiškai sugrąžins JSON atsakymą
            }
            catch (System.Exception ex)
            {
                // Jei įvyko klaida
                _logger.LogError(ex, "Klaida gavus naudotojo su ID {UserId} detales.", id);
                return StatusCode(500, "Įvyko klaida tvarkant duomenis.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> PridetiNaudotoja(Naudotojas naudotojas)
        {
            _logger.LogInformation("Pridedamas naujas naudotojas.");

            try
            {
                var isSuccess = await _naudotojųRepozitorija.PridėtiNaudotoją(naudotojas);

                if (!isSuccess)
                {
                    _logger.LogWarning("Nepavyko pridėti naudotojo.");
                    return StatusCode(400, "Nepavyko pridėti naudotojo.");
                }

                return Ok("Naudotojas sėkmingai pridėtas.");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Klaida pridedant naudotoją.");
                return StatusCode(500, "Įvyko klaida tvarkant duomenis.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> IstrintiNaudotoja(int id)
        {
            _logger.LogInformation("Ištrinamas naudotojas su ID: {UserId}", id);

            try
            {
                var isSuccess = await _naudotojųRepozitorija.IštrintiNaudotoją(id);

                if (!isSuccess)
                {
                    _logger.LogWarning("Naudotojas su ID {UserId} nerastas.", id);
                    return NotFound();
                }

                return Ok("Naudotojas sėkmingai ištrintas.");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Klaida trinant naudotoją su ID {UserId}.", id);
                return StatusCode(500, "Įvyko klaida tvarkant duomenis.");
            }
        }

    }
}
