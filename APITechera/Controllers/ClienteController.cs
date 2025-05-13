using APITechera.BE.Dtos.ClienteDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APITechera.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IEnumerable<TbCliente> ListarClientes()
        {
            return _clienteService.ListarClientes();
        }

        [HttpGet("ClientePorNombre")]
        public IEnumerable<ClienteDTO> ClientePorNombre(string nombreCia)
        {
            return _clienteService.ClientePorNombre(nombreCia);
        }

        [HttpGet("ClientePorPais")]
        public IEnumerable<ClienteDTO> ClientePorPais(string pais)
        {
            return _clienteService.ClientePorPais(pais);
        }

        [HttpPost]
        public ActionResult<TbCliente> CrearCliente(TbCliente entidad)
        {
            return Ok(_clienteService.CrearCliente(entidad));
        }

        [HttpPut]
        public ActionResult<TbCliente> EditarCliente(string nombreCia, TbCliente entidad)
        {
            return Ok(_clienteService.EditarCliente(nombreCia, entidad));
        }

        [HttpDelete]
        public IActionResult EliminarCliente(string nombreCia)
        {
            _clienteService.EliminarCliente(nombreCia);
            return NoContent();
        }
    }
}
