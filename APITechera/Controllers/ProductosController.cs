using APITechera.BE.Dtos.ProductDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APITechera.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public IEnumerable<TbProducto> ListarProductos()
        {
            return _productoService.ListarProductos();
        }

        [HttpGet("ProductosPorProveedor")]
        public IEnumerable<ProductoDTO> ProductosPorProveedor(string nombreProveedor)
        {
            return _productoService.ProductosPorProveedor(nombreProveedor);
        }

        [HttpGet("ProductosPorCategoria")]
        public IEnumerable<ProductoDTO> ProductosPorCategoria(string nombreCategoria)
        {
            return _productoService.ProductosPorCategoria(nombreCategoria);
        }

        [HttpGet("StockProducto")]
        public IEnumerable<StockDTO> StockProducto(string nombreProducto)
        {
            return _productoService.StockProducto(nombreProducto);
        }

        [HttpPost]
        public ActionResult<TbProducto> RegistrarProducto(ProductoDTO entidad)
        {
            return Ok(_productoService.RegistrarProducto(entidad));
        }

        [HttpPut]
        public ActionResult<TbProducto> EditarProducto(string nombreProducto, ProductoDTO entidad)
        {
            return Ok(_productoService.EditarProducto(nombreProducto, entidad));
        }

        [HttpDelete]
        public IActionResult EliminarProducto(string nombreProducto)
        {
            _productoService.EliminarProducto(nombreProducto);
            return NoContent();
        }
    }
}
