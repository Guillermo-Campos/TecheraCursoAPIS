using APITechera.BE.Dtos.FacturaDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using APITechera.DA.IRepository;

namespace APITechera.BL.Services
{
    public class FacturaDetaService : IFacturaDetaService
    {
        private readonly IFacturaDetaRepository _facturaDetaRepository;

        public FacturaDetaService(IFacturaDetaRepository facturaDetaRepository)
        {
            _facturaDetaRepository = facturaDetaRepository;
        }

        public IEnumerable<TbFacturaDeta> ListarFacturas()
        {
            return _facturaDetaRepository.ListarFacturas();
        }

        public IEnumerable<FacturaDetaDTO> ListarFacturasPorProducto(string nombreProducto)
        {
            return _facturaDetaRepository.ListarFacturasPorProducto(nombreProducto);
        }

        public TbFacturaDeta CrearFactura(FacturaDetaDTO entidad)
        {
            return _facturaDetaRepository.CrearFactura(entidad);
        }

        public TbFacturaDeta EditarFactura(int idFacturaCabe, FacturaDetaDTO entidad)
        {
            return _facturaDetaRepository.EditarFactura(idFacturaCabe, entidad);
        }

        public void EliminarFactura(int idFacturaCabe)
        {
            _facturaDetaRepository.EliminarFactura(idFacturaCabe);
        }
    }
}
