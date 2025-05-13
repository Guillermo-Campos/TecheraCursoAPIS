using APITechera.BE.Dtos.CategoriaDTO;
using APITechera.BE.Models;
using APITechera.DA.Data;
using APITechera.DA.IRepository;

namespace APITechera.DA.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TbCategoria> ListarCategorias()
        {
            return _context.tb_categorias.ToList();
        }

        public IEnumerable<string> CategoriaPorNombre(string nombreCategoria)
        {
            var categoria = _context.tb_categorias.Where(x => x.NombreCategoria.Contains(nombreCategoria)).Select(x => x.NombreCategoria);
            
            if(categoria != null)
            {
                return categoria;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró una categoria con el nombre {nombreCategoria}");
            }
        }

        public TbCategoria CrearCategoria(CategoriaDTO entidad)
        {
            var categoriaNueva = new TbCategoria()
            {
                NombreCategoria = entidad.NombreCategoria,
                Descripcion = entidad.Descripcion,
            };

            _context.tb_categorias.Add(categoriaNueva);
            _context.SaveChanges();

            return categoriaNueva;
        }

        public TbCategoria EditarCategoria(string nombreCategoria, CategoriaDTO entidad)
        {
            var usuarioEditar = _context.tb_categorias.FirstOrDefault(x => x.NombreCategoria.Contains(nombreCategoria));

            if(usuarioEditar != null)
            {
                usuarioEditar.NombreCategoria = entidad.NombreCategoria;
                usuarioEditar.Descripcion = entidad.Descripcion;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró una categoria con el nombre {nombreCategoria}");
            }

            _context.tb_categorias.Update(usuarioEditar);
            _context.SaveChanges();

            return usuarioEditar;
        }

        public void EliminarCategoria(string nombreCategoria)
        {
            var categoriaEliminar = _context.tb_categorias.FirstOrDefault(x => x.NombreCategoria.Contains(nombreCategoria));

            if(categoriaEliminar != null)
            {
                _context.tb_categorias.Remove(categoriaEliminar);
                _context.SaveChanges();
            }
        }
    }
}
