using APITechera.BE.Dtos.ClienteDTO;
using APITechera.BE.Models;

namespace APITechera.DA.IRepository
{
    public interface IClienteRepository
    {
        IEnumerable<TbCliente> ListarClientes();

        IEnumerable<ClienteDTO> ClientePorNombre(string nombreCia);

        IEnumerable<ClienteDTO> ClientesPorPais(string pais);

        TbCliente CrearCliente(TbCliente entidad);

        TbCliente EditarCliente(string nombreCia, TbCliente entidad);

        void EliminarCliente(string nombreCia);
    }
}
