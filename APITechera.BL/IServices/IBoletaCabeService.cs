using APITechera.BE.Dtos.BoletaDTO;
using APITechera.BE.Models;

namespace APITechera.BL.IServices
{
    public interface IBoletaCabeService
    {
        IEnumerable<TbBoletaCabe> ListarBoletas();

        IEnumerable<BoletaCabeDTO> ListarBoletasPorCliente(string nombreCliente);

        IEnumerable<BoletaCabeDTO> ListarBoletasPorEmpleado(string nombreEmpleado);

        IEnumerable<BoletaCabeDTO> ListarBoletasPorPedido(int idPedido);

        TbBoletaCabe CrearBoletaCabe(BoletaCabeDTO entidad);

        TbBoletaCabe EditarBoletaCabe(int pedido, BoletaCabeDTO entidad);

        void EliminarBoletaCabe(int pedido);
    }
}
