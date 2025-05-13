using APITechera.BE.Dtos.PedidoDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APITechera.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoDetaController : Controller
    {
        private readonly IPedidoDetaService _pedidoDetaService;

        public PedidoDetaController(IPedidoDetaService pedidoDetaService)
        {
            _pedidoDetaService = pedidoDetaService;
        }

        [HttpGet]
        public IEnumerable<TbPedidoDeta> ListarPedidos()
        {
            return _pedidoDetaService.ListarPedidos();
        }

        [HttpGet("ListarPedidosPorProducto")]
        public IEnumerable<PedidoDetaDTO> ListarPedidosPorProducto(string nombreProducto)
        {
            return _pedidoDetaService.ListarPedidosPorProducto(nombreProducto);
        }

        [HttpPost]
        public ActionResult<TbPedidoDeta> CrearPedidoDeta(PedidoDetaDTO entidad)
        {
            return Ok(_pedidoDetaService.CrearPedidoDeta(entidad));
        }

        [HttpPut]
        public ActionResult<TbPedidoDeta> EditarPedidoDeta(int idPedidoDeta, PedidoDetaDTO entidad)
        {
            return Ok(_pedidoDetaService.EditarPedidoDeta(idPedidoDeta, entidad));
        }

        [HttpDelete]
        public IActionResult EliminarPedido(int idPedidoDeta)
        {
            _pedidoDetaService.EliminarPedido(idPedidoDeta);
            return NoContent();
        }
    }
}
