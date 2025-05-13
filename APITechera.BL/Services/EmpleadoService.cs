using APITechera.BE.Dtos.EmpleadoDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using APITechera.DA.IRepository;

namespace APITechera.BL.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public IEnumerable<TbEmpleado> ListarEmpleados()
        {
            return _empleadoRepository.ListarEmpleados();
        }

        public IEnumerable<EmpleadoDTO> EmpleadoPorNombre(string nombre, string apellidos)
        {
            return _empleadoRepository.EmpleadoPorNombre(nombre, apellidos);
        }

        public IEnumerable<EmpleadoDTO> EmpleadosPorCargo(string cargo)
        {
            return _empleadoRepository.EmpleadosPorCargo(cargo);
        }

        public TbEmpleado RegistrarEmpleado(EmpleadoDTO entidad)
        {
            return _empleadoRepository.RegistrarEmpleado(entidad);
        }

        public TbEmpleado EditarEmpleado(string nombre, string apellidos, EmpleadoDTO entidad)
        {
            return _empleadoRepository.EditarEmpleado(nombre, apellidos, entidad);
        }

        public void EliminarEmpleado(string nombres, string apellidos)
        {
            _empleadoRepository.EliminarEmpleado(nombres, apellidos);
        }
    }
}
