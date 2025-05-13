using APITechera.BE.Dtos.FacturaDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using APITechera.DA.IRepository;

namespace APITechera.BL.Services
{
    public class FacturaCabeService : IFacturaCabeService
    {
        private readonly IFacturaCabeRepository _facturaCabeRepository;

        public FacturaCabeService(IFacturaCabeRepository facturaCabeRepository)
        {
            _facturaCabeRepository = facturaCabeRepository;
        }

        public IEnumerable<TbFacturaCabe> ListarFacturas()
        {
            return _facturaCabeRepository.ListarFacturas();
        }

        public IEnumerable<FacturaCabeDTO> ListarFacturasPorCLiente(string nombreCliente)
        {
            return _facturaCabeRepository.ListarFacturasPorCLiente(nombreCliente);
        }

        public IEnumerable<FacturaCabeDTO> ListarFacturasPorEmpleado(string nombreEmpleado)
        {
            return _facturaCabeRepository.ListarFacturasPorEmpleado(nombreEmpleado);
        }

        public TbFacturaCabe CrearFactura(FacturaCabeDTO entidad)
        {
            return _facturaCabeRepository.CrearFactura(entidad);
        }

        public TbFacturaCabe EditarFactura(int IdPedidoCabe, FacturaCabeDTO entidad)
        {
            return _facturaCabeRepository.EditarFactura(IdPedidoCabe, entidad);
        }

        public void EliminarFactura(int idFacturaCabe)
        {
            _facturaCabeRepository.EliminarFactura(idFacturaCabe);
        }
    }
}
