using APITechera.BE.Models;
using APITechera.BL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APITechera.WEB.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PaisController : Controller
    {
        private IPaisService _paisService;

        public PaisController(IPaisService paisService)
        {
            _paisService = paisService;
        }

        [HttpGet]
        public IEnumerable<TbPais> ListarPaises()
        {
            return _paisService.ListarPaises();
        }

        [HttpGet("PaisPorNombre")]
        public IEnumerable<string> PaisPorNombre(string nombrePais)
        {
            return _paisService.PaisPorNombre(nombrePais);
        }

        [HttpPost]
        public ActionResult<TbPais> CrearPais(string nombrePais)
        {
            return Ok(_paisService.CrearPais(nombrePais));
        }

        [HttpPut]
        public ActionResult<TbPais> EditarPais(string nombrePais, string nuevoNombrePais)
        {
            return Ok(_paisService.EditarPais(nombrePais, nuevoNombrePais));
        }

        [HttpDelete]
        public IActionResult EliminarPais(string nombrePais)
        {
            _paisService.EliminarPais(nombrePais);
            return NoContent();
        }
    }
}
