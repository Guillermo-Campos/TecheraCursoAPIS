using APITechera.BE.Models;
using APITechera.BL.IServices;
using APITechera.DA.IRepository;

namespace APITechera.BL.Services
{
    public class PaisService : IPaisService
    {
        private readonly IPaisRepository _paisRepository;

        public PaisService(IPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }

        public IEnumerable<TbPais> ListarPaises()
        {
            return _paisRepository.ListarPaises();
        }

        public IEnumerable<string> PaisPorNombre(string nombrePais)
        {
            return _paisRepository.PaisPorNombre(nombrePais);
        }

        public TbPais CrearPais(string nombrePais)
        {
            return _paisRepository.CrearPais(nombrePais);
        }

        public TbPais EditarPais(string nombrePais, string nuevoNombrePais)
        {
            return _paisRepository.EditarPais(nombrePais, nuevoNombrePais);
        }

        public void EliminarPais(string nombrePais)
        {
            _paisRepository.EliminarPais(nombrePais);
        }
    }
}
