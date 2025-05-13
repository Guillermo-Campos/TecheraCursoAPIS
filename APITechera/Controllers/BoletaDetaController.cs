using APITechera.BE.Dtos.BoletaDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APITechera.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletaDetaController : Controller
    {
        private readonly IBoletaDetaService _boletaDetaService;

        public BoletaDetaController(IBoletaDetaService boletaDetaService)
        {
            _boletaDetaService = boletaDetaService;
        }

        [HttpGet]
        public IEnumerable<TbBoletaDeta> ListarBoletas()
        {
            return _boletaDetaService.ListarBoletas();
        }

        [HttpGet("ListarBoletaPorNombreProducto")]
        public IEnumerable<BoletaDetaDTO> ListarBoletaPorNombreProducto(string nombreProducto)
        {
            return _boletaDetaService.ListarBoletaPorNombreProducto(nombreProducto);
        }

        [HttpPost]
        public ActionResult<TbBoletaDeta> CrearBoletaDeta(BoletaDetaDTO entidad)
        {
            return Ok(_boletaDetaService.CrearBoletaDeta(entidad));
        }

        [HttpPut]
        public ActionResult<TbBoletaDeta> EditarBoletaDeta(string nombreProducto, BoletaDetaDTO entidad)
        {
            return Ok(_boletaDetaService.EditarBoletaDeta(nombreProducto, entidad));
        }

        [HttpDelete]
        public IActionResult EliminarBoletaDeta(string nombreProducto)
        {
            _boletaDetaService.EliminarBoletaDeta(nombreProducto);
            return NoContent();
        }
    }
}
