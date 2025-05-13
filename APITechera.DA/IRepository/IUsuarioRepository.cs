using APITechera.BE.Dtos.TbUsuarioDTO;
using APITechera.BE.Models;

namespace APITechera.DA.IRepository
{
    public interface IUsuarioRepository
    {
        IEnumerable<TbUsuario> ListarUsuarios();

        IEnumerable<string> UsuarioPorNombre(string logon);

        TbUsuario CrearUsuario(UsuarioDTO entidad);

        TbUsuario EditarUsuario(string logon, UsuarioDTO entidad);

        void EliminarUsuario(string logon);
    }
}
