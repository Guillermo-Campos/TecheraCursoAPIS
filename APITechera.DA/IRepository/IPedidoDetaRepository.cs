using APITechera.BE.Dtos.PedidoDTO;
using APITechera.BE.Models;

namespace APITechera.DA.IRepository
{
    public interface IPedidoDetaRepository
    {
        IEnumerable<TbPedidoDeta> ListarPedidos();

        IEnumerable<PedidoDetaDTO> ListarPedidosPorProducto(string nombreProducto);

        TbPedidoDeta CrearPedidoDeta(PedidoDetaDTO entidad);

        TbPedidoDeta EditarPedidoDeta(int idPedidoDeta, PedidoDetaDTO entidad);

        void EliminarPedido(int idPedidoDeta);
    }
}
