using APITechera.BE.Dtos.BoletaDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using APITechera.DA.IRepository;

namespace APITechera.BL.Services
{
    public class BoletaDetaService : IBoletaDetaService
    {
        private readonly IBoletaDetaRepository _boletaDetaRepository;

        public BoletaDetaService(IBoletaDetaRepository boletaDetaRepository)
        {
            _boletaDetaRepository = boletaDetaRepository;
        }

        public IEnumerable<TbBoletaDeta> ListarBoletas()
        {
            return _boletaDetaRepository.ListarBoletas();
        }

        public IEnumerable<BoletaDetaDTO> ListarBoletaPorNombreProducto(string nombreProducto)
        {
            return _boletaDetaRepository.ListarBoletaPorNombreProducto(nombreProducto);
        }

        public TbBoletaDeta CrearBoletaDeta(BoletaDetaDTO entidad)
        {
            return _boletaDetaRepository.CrearBoletaDeta(entidad);
        }

        public TbBoletaDeta EditarBoletaDeta(string nombreProducto, BoletaDetaDTO entidad)
        {
            return _boletaDetaRepository.EditarBoletaDeta(nombreProducto, entidad);
        }

        public void EliminarBoletaDeta(string nombreProducto)
        {
            _boletaDetaRepository.EliminarBoletaDeta(nombreProducto);
        }
    }
}
