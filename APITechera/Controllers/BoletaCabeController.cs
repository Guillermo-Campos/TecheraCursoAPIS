using APITechera.BE.Dtos.BoletaDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using APITechera.DA.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace APITechera.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletaCabeController : Controller
    {
        private readonly IBoletaCabeService _boletaCabeService;

        public BoletaCabeController(IBoletaCabeService boletaCabeService)
        {
            _boletaCabeService = boletaCabeService;
        }

        [HttpGet]
        public IEnumerable<TbBoletaCabe> ListarBoletas()
        {
            return _boletaCabeService.ListarBoletas();
        }

        [HttpGet("ListarBoletasPorCliente")]
        public IEnumerable<BoletaCabeDTO> ListarBoletasPorCliente(string nombreCliente)
        {
            return _boletaCabeService.ListarBoletasPorCliente(nombreCliente);
        }

        [HttpGet("ListarBoletasPorEmpleado")]
        public IEnumerable<BoletaCabeDTO> ListarBoletasPorEmpleado(string nombreEmpleado)
        {
            return _boletaCabeService.ListarBoletasPorEmpleado(nombreEmpleado);
        }

        [HttpGet("ListarBoletasPorPedido")]
        public IEnumerable<BoletaCabeDTO> ListarBoletasPorPedido(int idPedido)
        {
            return _boletaCabeService.ListarBoletasPorPedido(idPedido);
        }

        [HttpPost]
        public ActionResult<TbBoletaCabe> CrearBoletaCabe(BoletaCabeDTO entidad)
        {
            return Ok(_boletaCabeService.CrearBoletaCabe(entidad));
        }

        [HttpPut]
        public ActionResult<TbBoletaCabe> EditarBoletaCabe(int pedido, BoletaCabeDTO entidad)
        {
            return Ok(_boletaCabeService.EditarBoletaCabe(pedido, entidad));
        }

        [HttpDelete]
        public IActionResult EliminarBoletaCabe(int pedido)
        {
            _boletaCabeService.EliminarBoletaCabe(pedido);
            return NoContent();
        }
    }
}
