using APITechera.BE.Dtos.ProveedorDTO;
using APITechera.BE.Models;

namespace APITechera.BL.IServices
{
    public interface IProveedorService
    {
        IEnumerable<TbProveedor> ListarProveedores();

        IEnumerable<ProveedorDTO> ProveedoresPorCia(string nombreCia);

        IEnumerable<ProveedorDTO> ProveedorPorNombre(string nombreContacto);

        TbProveedor CrearProveedor(ProveedorDTO entidad);

        TbProveedor EditarProveedor(string nombreCia, ProveedorDTO entidad);

        void EliminarProveedor(string nombreCia);
    }
}
