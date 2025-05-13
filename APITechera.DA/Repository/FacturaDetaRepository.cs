using APITechera.BE.Dtos.FacturaDTO;
using APITechera.BE.Models;
using APITechera.DA.Data;
using APITechera.DA.IRepository;

namespace APITechera.DA.Repository
{
    public class FacturaDetaRepository : IFacturaDetaRepository
    {
        private readonly ApplicationDbContext _context;

        public FacturaDetaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TbFacturaDeta> ListarFacturas()
        {
            return _context.tb_facturasdeta.ToList();
        }

        public IEnumerable<FacturaDetaDTO> ListarFacturasPorProducto(string nombreProducto)
        {
            var factura = (from f in _context.tb_facturasdeta
                           join p in _context.tb_productos on f.IdProducto equals p.IdProducto
                           where p.NombreProducto.Contains(nombreProducto)
                           select new FacturaDetaDTO()
                           {
                               IdFacturaCabe = f.IdFacturaCabe,
                               NombreProducto = p.NombreProducto,
                               PrecioUnidad = p.PrecioUnidad,
                               Cantidad = f.Cantidad,
                           });

            if(factura != null)
            {
                return factura.ToList();
            }
            else
            {
                throw new InvalidOperationException($"No se encontró facturas para el producto {nombreProducto}");
            }
        }

        public TbFacturaDeta CrearFactura(FacturaDetaDTO entidad)
        {
            var idProducto = _context.tb_productos.Where(x => x.NombreProducto.Contains(entidad.NombreProducto)).Select(x => x.IdProducto).FirstOrDefault();

            var facturaNueva = new TbFacturaDeta()
            {
                IdFacturaCabe = entidad.IdFacturaCabe,
                IdProducto = idProducto,
                PrecioUnidad = entidad.PrecioUnidad,
                Cantidad = entidad.Cantidad,
            };

            _context.tb_facturasdeta.Add(facturaNueva);
            _context.SaveChanges();

            return facturaNueva;

        }

        public TbFacturaDeta EditarFactura(int idFacturaDeta, FacturaDetaDTO entidad)
        {
            var idProducto = _context.tb_productos
                            .Where(x => x.NombreProducto.Contains(entidad.NombreProducto))
                            .Select(x => x.IdProducto).FirstOrDefault();

            var facturaEditar = _context.tb_facturasdeta.FirstOrDefault(x => x.IdFacturaDeta == idFacturaDeta);

            if(facturaEditar == null)
            {
                facturaEditar.IdFacturaDeta = entidad.IdFacturaCabe;
                facturaEditar.IdProducto = idProducto;
                facturaEditar.PrecioUnidad = entidad.PrecioUnidad;
                facturaEditar.Cantidad = entidad.Cantidad;
            }
            else
            {
                throw new InvalidOperationException($"No se encontraron facturas con el id del pedido");
            }

            _context.tb_facturasdeta.Update(facturaEditar);
            _context.SaveChanges();

            return facturaEditar;
        }

        public void EliminarFactura(int idFacturaCabe)
        {
            var facturaEliminar = _context.tb_facturasdeta.FirstOrDefault(x => x.IdFacturaCabe == idFacturaCabe);

            if(facturaEliminar != null)
            {
                _context.tb_facturasdeta.Remove(facturaEliminar);
                _context.SaveChanges();
            }
        }
    }
}
