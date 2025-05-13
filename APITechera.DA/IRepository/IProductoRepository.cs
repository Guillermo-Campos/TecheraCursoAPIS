using APITechera.BE.Dtos.ProductDTO;
using APITechera.BE.Models;

namespace APITechera.DA.IRepository
{
    public interface IProductoRepository
    {
        IEnumerable<TbProducto> ListarProductos();

        IEnumerable<ProductoDTO> ProductosPorProveedor(string nombreProveedor);

        IEnumerable<ProductoDTO> ProductosPorCategoria(string nombreCategoria);

        IEnumerable<StockDTO> StockProducto(string nombreProducto);

        TbProducto RegistrarProducto(ProductoDTO entidad);

        TbProducto EditarProducto(string nombreProducto, ProductoDTO entidad);

        void EliminarProducto(string nombreProducto);
    }
}
