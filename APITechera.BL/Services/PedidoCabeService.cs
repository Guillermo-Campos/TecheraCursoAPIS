using APITechera.BE.Dtos.PedidoDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using APITechera.DA.IRepository;

namespace APITechera.BL.Services
{
    public class PedidoCabeService : IPedidoCabeService
    {
        private readonly IPedidoCabeRepository _pedidoCabeRepository;

        public PedidoCabeService(IPedidoCabeRepository pedidoCabeRepository)
        {
            _pedidoCabeRepository = pedidoCabeRepository;
        }

        public IEnumerable<TbPedidoCabe> ListarPedidos()
        {
            return _pedidoCabeRepository.ListarPedidos();
        }

        public IEnumerable<PedidoCabeDTO> ListarPedidosPorCliente(string nombreCliente)
        {
            return _pedidoCabeRepository.ListarPedidosPorCliente(nombreCliente);
        }

        public IEnumerable<PedidoCabeDTO> ListarPedidosPorEmpleados(string nombreEmpleado)
        {
            return _pedidoCabeRepository.ListarPedidosPorEmpleados(nombreEmpleado);
        }

        public TbPedidoCabe CrearPedido(PedidoCabeDTO entidad)
        {
            return _pedidoCabeRepository.CrearPedido(entidad);
        }

        public TbPedidoCabe EditarPedido(int idPedidoCabe, PedidoCabeDTO entidad)
        {
            return _pedidoCabeRepository.EditarPedido(idPedidoCabe, entidad);
        }

        public void EliminarPedido(int idPedidoCabe)
        {
            _pedidoCabeRepository.EliminarPedido(idPedidoCabe);
        }
    }
}
