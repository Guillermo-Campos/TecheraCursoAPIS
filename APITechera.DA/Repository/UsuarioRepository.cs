using APITechera.BE.Dtos.TbUsuarioDTO;
using APITechera.BE.Models;
using APITechera.DA.Data;
using APITechera.DA.IRepository;
using Microsoft.EntityFrameworkCore;

namespace APITechera.DA.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TbUsuario> ListarUsuarios()
        {
            return _context.tb_usuarios.ToList();
        }

        public IEnumerable<string> UsuarioPorNombre(string logon)
        {
            var usuario = _context.tb_usuarios.Where(X => X.Logon.Contains(logon)).Select(x => x.Logon);
            if(usuario != null)
            {
                return usuario;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró un usuario con el nombre {logon}");
            }
        }

        public TbUsuario CrearUsuario(UsuarioDTO entidad)
        {
            var usuarioNuevo = new TbUsuario()
            {
                Logon = entidad.Logon,
                Clave = entidad.Clave,
            };

            _context.tb_usuarios.Add(usuarioNuevo);
            _context.SaveChanges();
            return usuarioNuevo;
        }

        public TbUsuario EditarUsuario(string logon, UsuarioDTO entidad)
        {
            try
            {
                var usuarioActualizar = _context.tb_usuarios.FirstOrDefault(x => x.Logon.Contains(logon));
                if (usuarioActualizar != null)
                {
                    usuarioActualizar.Logon = entidad.Logon;
                    usuarioActualizar.Clave = entidad.Clave;
                }
                else
                {
                    throw new InvalidOperationException($"No se encontró un usuario con el nombre {logon}");
                }

                _context.tb_usuarios.Update(usuarioActualizar);
                _context.SaveChanges();

                return usuarioActualizar;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error al actualizar la base de datos: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw;
            }
        }

        public void EliminarUsuario(string logon)
        {
            var usuarioEliminar = _context.tb_usuarios.FirstOrDefault(x => x.Logon.Contains(logon));
            if (usuarioEliminar != null)
            {
                _context.tb_usuarios.Remove(usuarioEliminar);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException($"No se encontró un usuario con el nombre {logon}");
            }
        }
    }
}
