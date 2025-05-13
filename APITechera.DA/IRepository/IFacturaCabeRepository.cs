using APITechera.BE.Dtos.FacturaDTO;
using APITechera.BE.Models;

namespace APITechera.DA.IRepository
{
    public interface IFacturaCabeRepository
    {
        IEnumerable<TbFacturaCabe> ListarFacturas();

        IEnumerable<FacturaCabeDTO> ListarFacturasPorCLiente(string nombreCliente);

        IEnumerable<FacturaCabeDTO> ListarFacturasPorEmpleado(string nombreEmpleado);

        TbFacturaCabe CrearFactura(FacturaCabeDTO entidad);

        TbFacturaCabe EditarFactura(int IdPedidoCabe, FacturaCabeDTO entidad);

        void EliminarFactura(int idFacturaCabe);
    }
}
