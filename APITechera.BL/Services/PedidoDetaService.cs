using APITechera.BE.Dtos.PedidoDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using APITechera.DA.IRepository;

namespace APITechera.BL.Services
{
    public class PedidoDetaService : IPedidoDetaService
    {
        private readonly IPedidoDetaRepository _pedidoDetaRepository;

        public PedidoDetaService(IPedidoDetaRepository pedidoDetaRepository)
        {
            _pedidoDetaRepository = pedidoDetaRepository;
        }

        public IEnumerable<TbPedidoDeta> ListarPedidos()
        {
            return _pedidoDetaRepository.ListarPedidos();
        }

        public IEnumerable<PedidoDetaDTO> ListarPedidosPorProducto(string nombreProducto)
        {
            return _pedidoDetaRepository.ListarPedidosPorProducto(nombreProducto);
        }

        public TbPedidoDeta CrearPedidoDeta(PedidoDetaDTO entidad)
        {
            return _pedidoDetaRepository.CrearPedidoDeta(entidad);
        }

        public TbPedidoDeta EditarPedidoDeta(int idPedidoDeta, PedidoDetaDTO entidad)
        {
            return _pedidoDetaRepository.EditarPedidoDeta(idPedidoDeta, entidad);
        }

        public void EliminarPedido(int idPedidoDeta)
        {
            _pedidoDetaRepository.EliminarPedido(idPedidoDeta);
        }

        
    }
}
