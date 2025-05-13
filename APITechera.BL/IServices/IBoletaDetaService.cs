using APITechera.BE.Dtos.BoletaDTO;
using APITechera.BE.Models;

namespace APITechera.BL.IServices
{
    public interface IBoletaDetaService
    {
        IEnumerable<TbBoletaDeta> ListarBoletas();

        IEnumerable<BoletaDetaDTO> ListarBoletaPorNombreProducto(string nombreProducto);

        TbBoletaDeta CrearBoletaDeta(BoletaDetaDTO entidad);

        TbBoletaDeta EditarBoletaDeta(string nombreProducto, BoletaDetaDTO entidad);

        void EliminarBoletaDeta(string nombreProducto);
    }
}
