using APITechera.BE.Dtos.FacturaDTO;
using APITechera.BE.Models;

namespace APITechera.BL.IServices
{
    public interface IFacturaDetaService
    {
        IEnumerable<TbFacturaDeta> ListarFacturas();

        IEnumerable<FacturaDetaDTO> ListarFacturasPorProducto(string nombreProducto);

        TbFacturaDeta CrearFactura(FacturaDetaDTO entidad);

        TbFacturaDeta EditarFactura(int idFacturaCabe, FacturaDetaDTO entidad);

        void EliminarFactura(int idFacturaCabe);
    }
}
