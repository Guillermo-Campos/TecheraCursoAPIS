using APITechera.BE.Dtos.EmpleadoDTO;
using APITechera.BE.Models;

namespace APITechera.DA.IRepository
{
    public interface IEmpleadoRepository
    {
        IEnumerable<TbEmpleado> ListarEmpleados();

        IEnumerable<EmpleadoDTO> EmpleadoPorNombre(string nombre, string apellidos);

        IEnumerable<EmpleadoDTO> EmpleadosPorCargo(string cargo);

        TbEmpleado RegistrarEmpleado(EmpleadoDTO entidad);

        TbEmpleado EditarEmpleado(string nombre, string apellidos, EmpleadoDTO entidad);

        void EliminarEmpleado(string nombres, string apellidos);
    }
}
