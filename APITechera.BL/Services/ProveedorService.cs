using APITechera.BE.Dtos.ProveedorDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using APITechera.DA.IRepository;

namespace APITechera.BL.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorService(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public IEnumerable<TbProveedor> ListarProveedores()
        {
           return _proveedorRepository.ListarProveedores();
        }

        public IEnumerable<ProveedorDTO> ProveedoresPorCia(string nombreCia)
        {
            return _proveedorRepository.ProveedoresPorCia(nombreCia);
        }

        public IEnumerable<ProveedorDTO> ProveedorPorNombre(string nombreContacto)
        {
            return _proveedorRepository.ProveedorPorNombre(nombreContacto);
        }

        public TbProveedor CrearProveedor(ProveedorDTO entidad)
        {
            return _proveedorRepository.CrearProveedor(entidad);
        }

        public TbProveedor EditarProveedor(string nombreCia, ProveedorDTO entidad)
        {
            return _proveedorRepository.EditarProveedor(nombreCia, entidad);
        }

        public void EliminarProveedor(string nombreCia)
        {
            _proveedorRepository.EliminarProveedor(nombreCia);
        }
    }
}
