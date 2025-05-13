using APITechera.BE.Dtos.TbUsuarioDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using APITechera.DA.IRepository;

namespace APITechera.BL.Services
{
    public class UsuarioService : IUsuarioService
    {
        public readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<TbUsuario> ListarUsuarios()
        {
            return _usuarioRepository.ListarUsuarios();
        }

        public IEnumerable<string> UsuarioPorNombre(string logon)
        {
            return _usuarioRepository.UsuarioPorNombre(logon);
        }

        public TbUsuario CrearUsuario(UsuarioDTO entidad)
        {
            return _usuarioRepository.CrearUsuario(entidad);
        }

        public TbUsuario EditarUsuario(string logon, UsuarioDTO entidad)
        {
            return _usuarioRepository.EditarUsuario(logon,  entidad);
        }

        public void EliminarUsuario(string logon)
        {
            _usuarioRepository.EliminarUsuario(logon);
        }
    }
}
