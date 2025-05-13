using APITechera.BE.Dtos.FacturaDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APITechera.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaDetaController : Controller
    {
        private readonly IFacturaDetaService _facturaDetaService;

        public FacturaDetaController(IFacturaDetaService facturaDetaService)
        {
            _facturaDetaService = facturaDetaService;
        }

        [HttpGet]
        public IEnumerable<TbFacturaDeta> ListarFacturas()
        {
            return _facturaDetaService.ListarFacturas();
        }

        [HttpGet("ListarFacturasPorProducto")]
        public IEnumerable<FacturaDetaDTO> ListarFacturasPorProducto(string nombreProducto)
        {
            return _facturaDetaService.ListarFacturasPorProducto(nombreProducto);
        }

        [HttpPost]
        public ActionResult<TbFacturaDeta> CrearFactura(FacturaDetaDTO entidad)
        {
            return Ok(_facturaDetaService.CrearFactura(entidad));
        }

        [HttpPut]
        public ActionResult<TbFacturaDeta> EditarFactura(int idFacturaCabe, FacturaDetaDTO entidad)
        {
            return Ok(_facturaDetaService.EditarFactura(idFacturaCabe, entidad));
        }

        [HttpDelete]
        public IActionResult EliminarFactura(int idFacturaCabe)
        {
            _facturaDetaService.EliminarFactura(idFacturaCabe);
            return NoContent();
        }
    }
}
