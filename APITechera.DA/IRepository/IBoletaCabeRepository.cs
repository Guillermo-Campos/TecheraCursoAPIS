using APITechera.BE.Dtos.BoletaDTO;
using APITechera.BE.Models;

namespace APITechera.DA.IRepository
{
    public interface IBoletaCabeRepository
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
