using APITechera.BE.Dtos.CategoriaDTO;
using APITechera.BE.Models;

namespace APITechera.DA.IRepository
{
    public interface ICategoriaRepository
    {
        IEnumerable<TbCategoria> ListarCategorias();

        IEnumerable<string> CategoriaPorNombre(string nombreCategoria);

        TbCategoria CrearCategoria(CategoriaDTO entidad);

        TbCategoria EditarCategoria(string nombreCategoria, CategoriaDTO entidad);

        void EliminarCategoria(string nombreCategoria);
    }
}
