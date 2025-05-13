using APITechera.BE.Dtos.TbUsuarioDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APITechera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IEnumerable<TbUsuario> ListarUsuario()
        {
            return _usuarioService.ListarUsuarios();
        }

        [HttpGet("UsuarioPorNombre")]
        public IEnumerable<string> UsuarioPorNombre(string logon)
        {
            return _usuarioService.UsuarioPorNombre(logon);
        }

        [HttpPost]
        public ActionResult<TbUsuario> CrearUsuario(UsuarioDTO entidad)
        {
            return Ok(_usuarioService.CrearUsuario(entidad));
        }

        [HttpPut]
        public ActionResult<TbUsuario> EditarUsuario(string logon, UsuarioDTO entidad)
        {
            return Ok(_usuarioService.EditarUsuario(logon, entidad));
        }

        [HttpDelete]
        public IActionResult EliminarUsuario(string logon)
        {
            _usuarioService.EliminarUsuario(logon);
            return NoContent();
        }
    }
}