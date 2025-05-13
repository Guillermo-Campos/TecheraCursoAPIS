using APITechera.BE.Dtos.ProductDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using APITechera.DA.IRepository;

namespace APITechera.BL.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productRepository;

        public ProductoService(IProductoRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<TbProducto> ListarProductos()
        {
            return _productRepository.ListarProductos();
        }

        public IEnumerable<ProductoDTO> ProductosPorCategoria(string nombreCategoria)
        {
            return _productRepository.ProductosPorCategoria(nombreCategoria);
        }

        public IEnumerable<ProductoDTO> ProductosPorProveedor(string nombreProveedor)
        {
            return _productRepository.ProductosPorProveedor(nombreProveedor);
        }

        public IEnumerable<StockDTO> StockProducto(string nombreProducto)
        {
            return _productRepository.StockProducto(nombreProducto);
        }

        public TbProducto RegistrarProducto(ProductoDTO entidad)
        {
            return _productRepository.RegistrarProducto(entidad);
        }

        public TbProducto EditarProducto(string nombreProducto, ProductoDTO entidad)
        {
            return _productRepository.EditarProducto(nombreProducto, entidad);
        }

        public void EliminarProducto(string nombreProducto)
        {
            _productRepository.EliminarProducto(nombreProducto);
        }
    }
}
