using APITechera.BE.Dtos.PedidoDTO;
using APITechera.BE.Models;

namespace APITechera.BL.IServices
{
    public interface IPedidoDetaService
    {
        IEnumerable<TbPedidoDeta> ListarPedidos();

        IEnumerable<PedidoDetaDTO> ListarPedidosPorProducto(string nombreProducto);

        TbPedidoDeta CrearPedidoDeta(PedidoDetaDTO entidad);

        TbPedidoDeta EditarPedidoDeta(int idPedidoDeta, PedidoDetaDTO entidad);

        void EliminarPedido(int idPedidoDeta);
    }
}
