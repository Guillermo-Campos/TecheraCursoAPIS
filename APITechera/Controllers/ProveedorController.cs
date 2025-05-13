using APITechera.BE.Dtos.ProveedorDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APITechera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        public IEnumerable<TbProveedor> ListarProveedores()
        {
            return _proveedorService.ListarProveedores();
        }

        [HttpGet("ProveedoresPorCia")]
        public IEnumerable<ProveedorDTO> ProveedoresPorCia(string nombreCia)
        {
            return _proveedorService.ProveedoresPorCia(nombreCia);
        }

        [HttpGet("ProveedorPorNombre")]
        public IEnumerable<ProveedorDTO> ProveedorPorNombre(string nombreContacto)
        {
            return _proveedorService.ProveedorPorNombre(nombreContacto);
        }

        [HttpPost]
        public ActionResult<TbProveedor> CrearProveedor(ProveedorDTO entidad)
        {
            return Ok(_proveedorService.CrearProveedor(entidad));
        }

        [HttpPut]
        public ActionResult<TbProveedor> EditarProveedor(string nombreCia, ProveedorDTO entidad)
        {
            return Ok(_proveedorService.EditarProveedor(nombreCia, entidad));
        }

        [HttpDelete]
        public IActionResult EliminarProveedor(string nombreCia)
        {
            _proveedorService.EliminarProveedor(nombreCia);
            return NoContent();
        }
    }
}