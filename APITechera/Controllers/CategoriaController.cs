using APITechera.BE.Dtos.CategoriaDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APITechera.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IEnumerable<TbCategoria> ListarCategorias()
        {
            return _categoriaService.ListarCategorias();
        }

        [HttpGet("CategoriaPorNombre")]
        public IEnumerable<string> CategoriaPorNombre(string nombreCategoria)
        {
            return _categoriaService.CategoriaPorNombre(nombreCategoria);
        }

        [HttpPost]
        public ActionResult<TbCategoria> CrearCategoria(CategoriaDTO entidad)
        {
            return Ok(_categoriaService.CrearCategoria(entidad));
        }

        [HttpPut]
        public ActionResult<TbCategoria> EditarCategoria(string nombreCategoria, CategoriaDTO entidad)
        {
            return Ok(_categoriaService.EditarCategoria(nombreCategoria, entidad));
        }

        [HttpDelete]
        public IActionResult EliminarCategoria(string nombreCategoria)
        {
            _categoriaService.EliminarCategoria(nombreCategoria);
            return NoContent();
        }
    }
}
