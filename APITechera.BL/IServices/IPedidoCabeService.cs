using APITechera.BE.Dtos.PedidoDTO;
using APITechera.BE.Models;

namespace APITechera.BL.IServices
{
    public interface IPedidoCabeService
    {
        IEnumerable<TbPedidoCabe> ListarPedidos();

        IEnumerable<PedidoCabeDTO> ListarPedidosPorCliente(string nombreCliente);

        IEnumerable<PedidoCabeDTO> ListarPedidosPorEmpleados(string nombreEmpleado);

        TbPedidoCabe CrearPedido(PedidoCabeDTO entidad);

        TbPedidoCabe EditarPedido(int idPedidoCabe, PedidoCabeDTO entidad);

        void EliminarPedido(int idPedidoCabe);
    }
}
