using KnyguNuoma.Core.Contracts;
using KnyguNuoma.Core.Modeliai;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnyguNuoma.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KnygosController : ControllerBase
    {
        private readonly IKnyguRepozitorija _knyguRepozitorija;

        // Constructor to inject the repository
        public KnygosController(IKnyguRepozitorija knyguRepozitorija)
        {
            _knyguRepozitorija = knyguRepozitorija;
        }

       
        [HttpPost]
        public async Task<IActionResult> PridėtiKnygą([FromBody] Knyga knyga)
        {
            if (knyga == null)
            {
                return BadRequest("Knyga negali būti null.");
            }

            var isSuccess = await _knyguRepozitorija.PridėtiKnygą(knyga);

            if (isSuccess)
            {
                return Ok("Knyga sėkmingai pridėta.");
            }

            return StatusCode(500, "Įvyko klaida pridedant knygą.");
        }

        [HttpGet]
        public async Task<ActionResult<List<Knyga>>> GautiVisasKnygas()
        {
            var knygos = await _knyguRepozitorija.GautiVisasKnygas();

            if (knygos == null || knygos.Count == 0)
            {
                return NotFound("Knygos nerastos.");
            }

            return Ok(knygos);
        }

      
        [HttpGet("kategorija/{kategorija}")]
        public async Task<ActionResult<List<Knyga>>> GautiKnygasPagalKategoriją(string kategorija)
        {
            if (string.IsNullOrEmpty(kategorija))
            {
                return BadRequest("Kategorija negali būti tuščia.");
            }

            var knygos = await _knyguRepozitorija.GautiKnygasPagalKategoriją(kategorija);

            if (knygos == null || knygos.Count == 0)
            {
                return NotFound($"Knygos su kategorija '{kategorija}' nerastos.");
            }

            return Ok(knygos);
        }
    }
}
