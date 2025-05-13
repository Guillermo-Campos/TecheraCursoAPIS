using APITechera.BE.Dtos.ClienteDTO;
using APITechera.BE.Models;

namespace APITechera.BL.IServices
{
    public interface IClienteService
    {
        IEnumerable<TbCliente> ListarClientes();

        IEnumerable<ClienteDTO> ClientePorNombre(string nombreCia);

        IEnumerable<ClienteDTO> ClientePorPais(string pais);

        TbCliente CrearCliente(TbCliente entidad);

        TbCliente EditarCliente(string nombreCia, TbCliente entidad);

        void EliminarCliente(string nombreCia);
    }
}
