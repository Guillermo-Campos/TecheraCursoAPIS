using APITechera.BE.Dtos.ProductDTO;
using APITechera.BE.Models;
using APITechera.DA.Data;
using APITechera.DA.IRepository;

namespace APITechera.DA.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TbProducto> ListarProductos()
        {
            return _context.tb_productos.ToList();
        }

        public IEnumerable<ProductoDTO> ProductosPorCategoria(string nombreCategoria)
        {
            var producto = (from p in _context.tb_productos
                            join c in _context.tb_categorias on p.IdCategoria equals c.IdCategoria
                            join pro in _context.tb_proveedores on p.IdProveedor equals pro.IdProveedor
                            where c.NombreCategoria.Contains(nombreCategoria)
                            select new ProductoDTO()
                            {
                                NombreProducto = p.NombreProducto,
                                NombreProveedor = pro.NombreCia,
                                NombreCategoria = c.NombreCategoria,
                                PrecioUnidad = p.PrecioUnidad,
                                UnidadesEnExistencia = p.UnidadesEnExistencia,
                                UnidadesEnPedido = p.UnidadesEnPedido,
                            });

            if(producto != null)
            {
                return producto;
            }
            else
            {
                throw new InvalidOperationException($"No se encontraron productos para la categoría {nombreCategoria}");
            }
        }

        public IEnumerable<ProductoDTO> ProductosPorProveedor(string nombreProveedor)
        {
            var producto = (from p in _context.tb_productos
                            join c in _context.tb_categorias on p.IdCategoria equals c.IdCategoria
                            join pro in _context.tb_proveedores on p.IdProveedor equals pro.IdProveedor
                            where pro.NombreCia.Contains(nombreProveedor)
                            select new ProductoDTO()
                            {
                                NombreProducto = p.NombreProducto,
                                NombreProveedor = pro.NombreCia,
                                NombreCategoria = c.NombreCategoria,
                                PrecioUnidad = p.PrecioUnidad,
                                UnidadesEnExistencia = p.UnidadesEnExistencia,
                                UnidadesEnPedido = p.UnidadesEnPedido,
                            });

            if (producto != null)
            {
                return producto;
            }
            else
            {
                throw new InvalidOperationException($"No se encontraron productos para el proveedor {nombreProveedor}");
            }
        }

        public IEnumerable<StockDTO> StockProducto(string nombreProducto)
        {
            var stockProducto = _context.tb_productos
                           .Where(x => x.NombreProducto.Contains(nombreProducto))
                           .Select(x => new StockDTO()
                            {
                                UnidadesEnExistencia = x.UnidadesEnExistencia,
                                UnidadesEnPedido = x.UnidadesEnPedido,
                            });

            if (stockProducto != null)
            {
                return stockProducto;
            }
            else
            {
                throw new InvalidOperationException($"No hay stock para el producto {nombreProducto}");
            }
        }

        public TbProducto RegistrarProducto(ProductoDTO entidad)
        {
            var idCategoria = _context.tb_categorias
                              .Where(x => x.NombreCategoria.Contains(entidad.NombreCategoria))
                              .Select(x => x.IdCategoria).FirstOrDefault();

            var idProveedor = _context.tb_proveedores
                              .Where(x => x.NombreCia.Contains(entidad.NombreProveedor))
                              .Select(x => x.IdProveedor).FirstOrDefault();

            var productoNuevo = new TbProducto() 
            { 
                NombreProducto = entidad.NombreProducto,
                IdCategoria = idCategoria,
                IdProveedor = idProveedor,
                CantidadPorUnidad = entidad.CantidadPorUnidad,
                PrecioUnidad = entidad.PrecioUnidad,
                UnidadesEnExistencia = entidad.UnidadesEnExistencia,
                UnidadesEnPedido = entidad.UnidadesEnPedido,
            };

            _context.tb_productos.Add(productoNuevo);
            _context.SaveChanges();

            return productoNuevo;        
        }

        public TbProducto EditarProducto(string nombreProducto, ProductoDTO entidad)
        {
            var idCategoria = _context.tb_categorias
                              .Where(x => x.NombreCategoria.Contains(entidad.NombreCategoria))
                              .Select(x => x.IdCategoria).FirstOrDefault();

            var idProveedor = _context.tb_proveedores
                              .Where(x => x.NombreCia.Contains(entidad.NombreProveedor))
                              .Select(x => x.IdProveedor).FirstOrDefault();

            var productoEditar = _context.tb_productos.FirstOrDefault(x => x.NombreProducto.Contains(nombreProducto));

            if(productoEditar != null)
            {
                productoEditar.IdCategoria = idCategoria;
                productoEditar.IdProveedor = idProveedor;
                productoEditar.CantidadPorUnidad = entidad.CantidadPorUnidad;
                productoEditar.PrecioUnidad = entidad.PrecioUnidad;
                productoEditar.UnidadesEnExistencia = entidad.UnidadesEnExistencia;
                productoEditar.UnidadesEnPedido = entidad.UnidadesEnPedido;
            }
            else
            {
                throw new InvalidOperationException($"No se encontraron productos con el nombre {nombreProducto}");
            }

            _context.tb_productos.Update(productoEditar);
            _context.SaveChanges();

            return productoEditar;
        }

        public void EliminarProducto(string nombreProducto)
        {
            var productoEliminar = _context.tb_productos.FirstOrDefault(x => x.NombreProducto.Contains(nombreProducto));

            if(productoEliminar != null)
            {
                _context.tb_productos.Remove(productoEliminar);
                _context.SaveChanges();
            }
        }
    }
}
