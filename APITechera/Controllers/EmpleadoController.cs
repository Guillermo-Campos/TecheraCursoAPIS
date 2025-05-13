using APITechera.BE.Dtos.EmpleadoDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APITechera.WEB.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public IEnumerable<TbEmpleado> ListarEmpleados()
        {
            return _empleadoService.ListarEmpleados();
        }

        [HttpGet("EmpleadoPorNombre")]
        public IEnumerable<EmpleadoDTO> EmpleadoPorNombre(string nombre, string apellidos)
        {
            return _empleadoService.EmpleadoPorNombre(nombre, apellidos);
        }

        [HttpGet("EmpleadosPorCargo")]
        public IEnumerable<EmpleadoDTO> EmpleadosPorCargo(string cargo)
        {
            return _empleadoService.EmpleadosPorCargo(cargo);
        }

        [HttpPost]
        public ActionResult<TbEmpleado> RegistrarEmpleado(EmpleadoDTO entidad)
        {
            return Ok(_empleadoService.RegistrarEmpleado(entidad));
        }

        [HttpPut]
        public ActionResult<TbEmpleado> EditarEmpleado(string nombre, string apellidos, EmpleadoDTO entidad)
        {
            return Ok(_empleadoService.EditarEmpleado(nombre, apellidos, entidad));
        }

        [HttpDelete]
        public IActionResult EliminarEmpleado(string nombres, string apellidos)
        {
            _empleadoService.EliminarEmpleado(nombres, apellidos);
            return NoContent();
        }
    }
}
