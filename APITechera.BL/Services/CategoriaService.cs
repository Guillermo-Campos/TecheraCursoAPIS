using APITechera.BE.Dtos.CategoriaDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using APITechera.DA.IRepository;

namespace APITechera.BL.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IEnumerable<TbCategoria> ListarCategorias()
        {
            return _categoriaRepository.ListarCategorias();
        }

        public IEnumerable<string> CategoriaPorNombre(string nombreCategoria)
        {
            return _categoriaRepository.CategoriaPorNombre(nombreCategoria);
        }

        public TbCategoria CrearCategoria(CategoriaDTO entidad)
        {
            return _categoriaRepository.CrearCategoria(entidad);
        }

        public TbCategoria EditarCategoria(string nombreCategoria, CategoriaDTO entidad)
        {
            return _categoriaRepository.EditarCategoria(nombreCategoria, entidad);
        }

        public void EliminarCategoria(string nombreCategoria)
        {
            _categoriaRepository.EliminarCategoria(nombreCategoria);        
        }
    }
}
