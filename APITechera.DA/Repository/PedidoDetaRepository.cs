using APITechera.BE.Dtos.PedidoDTO;
using APITechera.BE.Models;
using APITechera.DA.Data;
using APITechera.DA.IRepository;

namespace APITechera.DA.Repository
{
    public class PedidoDetaRepository : IPedidoDetaRepository
    {
        private readonly ApplicationDbContext _context;

        public PedidoDetaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TbPedidoDeta> ListarPedidos()
        {
            return _context.tb_pedidosdeta.ToList();
        }

        public IEnumerable<PedidoDetaDTO> ListarPedidosPorProducto(string nombreProducto)
        {
            var pedido = (from p in _context.tb_pedidosdeta
                          join pro in _context.tb_productos on p.IdProducto equals pro.IdProducto
                          where pro.NombreProducto.Contains(nombreProducto)
                          select new PedidoDetaDTO()
                          {
                              IdPedidoCabe = p.IdPedidoCabe,
                              NombreProducto = pro.NombreProducto,
                              PrecioUnidad = p.PrecioUnidad,
                              Cantidad = p.Cantidad,
                              Descuento = p.Descuento,
                          });

            if(pedido != null)
            {
                return pedido;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró pedidos del producto {nombreProducto}");
            }
        }

        public TbPedidoDeta CrearPedidoDeta(PedidoDetaDTO entidad)
        {
            var idProducto = _context.tb_productos
                             .Where(x => x.NombreProducto.Contains(entidad.NombreProducto))
                             .Select(x => x.IdProducto).FirstOrDefault();

            var pedidoNuevo = new TbPedidoDeta()
            {
                IdPedidoCabe = entidad.IdPedidoCabe,
                IdProducto = idProducto,
                PrecioUnidad = entidad.PrecioUnidad,
                Cantidad = entidad.Cantidad,
                Descuento = entidad.Descuento,
            };

            _context.tb_pedidosdeta.Add(pedidoNuevo);
            _context.SaveChanges();

            return pedidoNuevo;
        }

        public TbPedidoDeta EditarPedidoDeta(int idPedidoDeta, PedidoDetaDTO entidad)
        {
            var idProducto = _context.tb_productos
                             .Where(x => x.NombreProducto.Contains(entidad.NombreProducto))
                             .Select(x => x.IdProducto).FirstOrDefault();

            var pedidoEditar = _context.tb_pedidosdeta.FirstOrDefault(x => x.IdPedidoDeta == idPedidoDeta);

            if (pedidoEditar == null)
            {
                pedidoEditar.IdPedidoCabe = entidad.IdPedidoCabe;
                pedidoEditar.IdProducto = idProducto;
                pedidoEditar.PrecioUnidad = entidad.PrecioUnidad;
                pedidoEditar.Cantidad = entidad.Cantidad;
                pedidoEditar.Descuento = entidad.Descuento;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró pedidos con el Id proporcionado");
            }

            _context.tb_pedidosdeta.Update(pedidoEditar);
            _context.SaveChanges();

            return pedidoEditar;
        }

        public void EliminarPedido(int idPedidoDeta)
        {
            var pedidoEliminar = _context.tb_pedidosdeta.FirstOrDefault(x => x.IdPedidoDeta == idPedidoDeta);

            if(pedidoEliminar != null)
            {
                _context.tb_pedidosdeta.Remove(pedidoEliminar);
                _context.SaveChanges();
            }
        }
    }
}
