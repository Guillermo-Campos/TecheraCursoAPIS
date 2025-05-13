using APITechera.BE.Dtos.PedidoDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APITechera.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoCabeController : Controller
    {
        private readonly IPedidoCabeService _pedidoCabeService;

        public PedidoCabeController(IPedidoCabeService pedidoCabeService)
        {
            _pedidoCabeService = pedidoCabeService;
        }

        [HttpGet]
        public IEnumerable<TbPedidoCabe> ListarPedidos()
        {
            return _pedidoCabeService.ListarPedidos();
        }

        [HttpGet("ListarPedidosPorCliente")]
        public IEnumerable<PedidoCabeDTO> ListarPedidosPorCliente(string nombreCliente)
        {
            return _pedidoCabeService.ListarPedidosPorCliente(nombreCliente);
        }

        [HttpGet("ListarPedidosPorEmpleados")]
        public IEnumerable<PedidoCabeDTO> ListarPedidosPorEmpleados(string nombreEmpleado)
        {
            return _pedidoCabeService.ListarPedidosPorEmpleados(nombreEmpleado);
        }

        [HttpPost]
        public ActionResult<TbPedidoCabe> CrearPedido(PedidoCabeDTO entidad)
        {
            return Ok(_pedidoCabeService.CrearPedido(entidad));
        }

        [HttpPut]
        public ActionResult<TbPedidoCabe> EditarPedido(int idPedidoCabe, PedidoCabeDTO entidad)
        {
            return Ok(_pedidoCabeService.EditarPedido(idPedidoCabe, entidad));
        }

        [HttpDelete]
        public IActionResult EliminarPedido(int idPedidoCabe)
        {
            _pedidoCabeService.EliminarPedido(idPedidoCabe);
            return NoContent();
        }
    }
}
