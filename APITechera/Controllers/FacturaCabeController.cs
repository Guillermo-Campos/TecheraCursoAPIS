using APITechera.BE.Dtos.FacturaDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APITechera.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaCabeController : Controller
    {
        private readonly IFacturaCabeService _facturaCabeService;

        public FacturaCabeController(IFacturaCabeService facturaCabeService)
        {
            _facturaCabeService = facturaCabeService;
        }

        [HttpGet]
        public IEnumerable<TbFacturaCabe> ListarFacturas()
        {
            return _facturaCabeService.ListarFacturas();
        }

        [HttpGet("ListarFacturasPorCLiente")]
        public IEnumerable<FacturaCabeDTO> ListarFacturasPorCLiente(string nombreCliente)
        {
            return _facturaCabeService.ListarFacturasPorCLiente(nombreCliente);
        }

        [HttpGet("ListarFacturasPorEmpleado")]
        public IEnumerable<FacturaCabeDTO> ListarFacturasPorEmpleado(string nombreEmpleado)
        {
            return _facturaCabeService.ListarFacturasPorEmpleado(nombreEmpleado);
        }

        [HttpPost]
        public ActionResult<TbFacturaCabe> CrearFactura(FacturaCabeDTO entidad)
        {
            return Ok(_facturaCabeService.CrearFactura(entidad));
        }

        [HttpPut]
        public ActionResult<TbFacturaCabe> EditarFactura(int IdPedidoCabe, FacturaCabeDTO entidad)
        {
            return Ok(_facturaCabeService.EditarFactura(IdPedidoCabe, entidad));
        }

        [HttpDelete]
        public IActionResult EliminarFactura(int idFacturaCabe)
        {
            _facturaCabeService.EliminarFactura(idFacturaCabe);
            return NoContent();
        }
    }
}
