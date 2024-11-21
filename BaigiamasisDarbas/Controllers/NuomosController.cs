using KnyguNuoma.Core.Contracts;
using KnyguNuoma.Core.Modeliai;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnyguNuoma.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NuomosController : ControllerBase
    {
        private readonly INuomosRepozitorija _nuomosRepozitorija;

        // Konstruktorius, kuris injekuoja NuomosRepozitorija
        public NuomosController(INuomosRepozitorija nuomosRepozitorija)
        {
            _nuomosRepozitorija = nuomosRepozitorija;
        }

        // 1. Pradėti nuomą
        [HttpPost("pradeti-nuoma")]
        public async Task<IActionResult> PradetiNuomą([FromBody] NuomosPradziaModel nuomosPradzia)
        {
            if (nuomosPradzia == null || nuomosPradzia.KnygosId <= 0 || nuomosPradzia.VartotojoId <= 0)
            {
                return BadRequest("Nepateikti visi reikalingi duomenys.");
            }

            try
            {
                await _nuomosRepozitorija.PradetiNuomą(nuomosPradzia.KnygosId, nuomosPradzia.VartotojoId, nuomosPradzia.PradziosData, nuomosPradzia.PabaigosData);
                return Ok("Nuoma pradėta sėkmingai.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Įvyko klaida: {ex.Message}");
            }
        }

        // 2. Užbaigti nuomą
        [HttpPost("uzbaigti-nuoma/{nuomosId}")]
        public async Task<IActionResult> UzbiegtiNuomą(int nuomosId)
        {
            if (nuomosId <= 0)
            {
                return BadRequest("Nepateiktas nuomos ID.");
            }

            try
            {
                await _nuomosRepozitorija.UzbiegtiNuomą(nuomosId);
                return Ok("Nuoma užbaigta sėkmingai.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Įvyko klaida: {ex.Message}");
            }
        }

        // 3. Gauti aktyvią nuomą pagal vartotojo Id
        [HttpGet("aktyvi-nuoma/{vartotojoId}")]
        public async Task<IActionResult> GautiAktyviaNuomą(int vartotojoId)
        {
            if (vartotojoId <= 0)
            {
                return BadRequest("Nepateiktas vartotojo ID.");
            }

            try
            {
                var nuoma = await _nuomosRepozitorija.GautiAktyviaNuomą(vartotojoId);
                if (nuoma == null)
                {
                    return NotFound("Nerasta aktyvios nuomos.");
                }

                return Ok(nuoma);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Įvyko klaida: {ex.Message}");
            }
        }

        // 4. Gauti nuomos istoriją pagal vartotojo Id
        [HttpGet("nuomos-istorija/{vartotojoId}")]
        public async Task<IActionResult> GautiNuomosIstoriją(int vartotojoId)
        {
            if (vartotojoId <= 0)
            {
                return BadRequest("Nepateiktas vartotojo ID.");
            }

            try
            {
                var nuomosIstorija = await _nuomosRepozitorija.GautiNuomosIstoriją(vartotojoId);
                return Ok(nuomosIstorija);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Įvyko klaida: {ex.Message}");
            }
        }

        // 5. Gauti klientus, kurie nuomojo konkrečią knygą
        [HttpGet("klientai-pagal-knyga/{knygosId}")]
        public async Task<IActionResult> GautiKlientusPagalKnygą(int knygosId)
        {
            if (knygosId <= 0)
            {
                return BadRequest("Nepateiktas knygos ID.");
            }

            try
            {
                var klientai = await _nuomosRepozitorija.GautiKlientusPagalKnygą(knygosId);
                return Ok(klientai);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Įvyko klaida: {ex.Message}");
            }
        }

        // 6. Gauti visas esamas nuomas
        [HttpGet("visos-esamos-nuomos")]
        public async Task<IActionResult> GautiVisasEsamasNuomas()
        {
            try
            {
                var visosNuomos = await _nuomosRepozitorija.GautiVisasEsamasNuomas();
                return Ok(visosNuomos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Įvyko klaida: {ex.Message}");
            }
        }
    }
}
