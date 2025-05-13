using APITechera.BE.Dtos.FacturaDTO;
using APITechera.BE.Models;

namespace APITechera.DA.IRepository
{
    public interface IFacturaDetaRepository
    {
        IEnumerable<TbFacturaDeta> ListarFacturas();

        IEnumerable<FacturaDetaDTO> ListarFacturasPorProducto(string nombreProducto);

        TbFacturaDeta CrearFactura(FacturaDetaDTO entidad);

        TbFacturaDeta EditarFactura(int idFacturaCabe, FacturaDetaDTO entidad);

        void EliminarFactura(int idFacturaCabe);
    }
}
