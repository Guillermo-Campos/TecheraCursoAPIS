using APITechera.BE.Dtos.ClienteDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using APITechera.DA.IRepository;
using APITechera.DA.Repository;

namespace APITechera.BL.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<TbCliente> ListarClientes()
        {
            return _clienteRepository.ListarClientes();
        }

        public IEnumerable<ClienteDTO> ClientePorNombre(string nombreCia)
        {
            return _clienteRepository.ClientePorNombre(nombreCia);
        }

        public IEnumerable<ClienteDTO> ClientePorPais(string pais)
        {
            return _clienteRepository.ClientesPorPais(pais);
        }

        public TbCliente CrearCliente(TbCliente entidad)
        {
            return _clienteRepository.CrearCliente(entidad);
        }

        public TbCliente EditarCliente(string nombreCia, TbCliente entidad)
        {
            return _clienteRepository.EditarCliente(nombreCia, entidad);
        }

        public void EliminarCliente(string nombreCia)
        {
            _clienteRepository.EliminarCliente(nombreCia);
        }
    }
}
