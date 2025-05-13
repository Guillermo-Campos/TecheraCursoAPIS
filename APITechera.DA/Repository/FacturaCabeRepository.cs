using APITechera.BE.Dtos.FacturaDTO;
using APITechera.BE.Models;
using APITechera.DA.Data;
using APITechera.DA.IRepository;

namespace APITechera.DA.Repository
{
    public class FacturaCabeRepository : IFacturaCabeRepository
    {
        private readonly ApplicationDbContext _context;

        public FacturaCabeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TbFacturaCabe> ListarFacturas()
        {
            return _context.tb_facturacabe.ToList();
        }

        public IEnumerable<FacturaCabeDTO> ListarFacturasPorCLiente(string nombreCliente)
        {
            var factura = (from f in _context.tb_facturacabe
                           join c in _context.tb_clientes on f.IdCliente equals c.IdCliente
                           join e in _context.tb_empleados on f.IdEmpleado equals e.IdEmpleado
                           where c.NombreCia.Contains(nombreCliente)
                           select new FacturaCabeDTO()
                           {
                               NombreCliente = c.NombreCia,
                               NombreEmpleado = e.Nombre,
                               IdPedidoCabe = f.IdPedidoCabe,
                               FechaFactura = f.FechaFactura,
                               Monto = f.Monto,
                               IGV = f.IGV,
                               Cancela = f.Cancela,
                           });

            if(factura != null)
            {
                return factura.ToList();
            }
            else
            {
                throw new InvalidOperationException($"No se encontraron facturas para el cliente {nombreCliente}");
            }
        }

        public IEnumerable<FacturaCabeDTO> ListarFacturasPorEmpleado(string nombreEmpleado)
        {
            var factura = (from f in _context.tb_facturacabe
                           join c in _context.tb_clientes on f.IdCliente equals c.IdCliente
                           join e in _context.tb_empleados on f.IdEmpleado equals e.IdEmpleado
                           where e.Nombre.Contains(nombreEmpleado)
                           select new FacturaCabeDTO()
                           {
                               NombreCliente = c.NombreCia,
                               NombreEmpleado = e.Nombre,
                               IdPedidoCabe = f.IdPedidoCabe,
                               FechaFactura = f.FechaFactura,
                               Monto = f.Monto,
                               IGV = f.IGV,
                               Cancela = f.Cancela,
                           });

            if (factura != null)
            {
                return factura.ToList();
            }
            else
            {
                throw new InvalidOperationException($"No se encontraron facturas para el empleado {nombreEmpleado}");
            }
        }

        public TbFacturaCabe CrearFactura(FacturaCabeDTO entidad)
        {
            var idCliente = _context.tb_clientes
                            .Where(x => x.NombreCia.Contains(entidad.NombreCliente))
                            .Select(x => x.IdCliente).FirstOrDefault();

            var idEmpleado = _context.tb_empleados
                             .Where(x => x.Nombre.Contains(entidad.NombreEmpleado))
                             .Select(x => x.IdEmpleado).FirstOrDefault();

            var facturaNueva = new TbFacturaCabe()
            {
                IdCliente = idCliente,
                IdEmpleado = idEmpleado,
                IdPedidoCabe = entidad.IdPedidoCabe,
                FechaFactura = entidad.FechaFactura,
                Monto = entidad.Monto,
                IGV = entidad.IGV,
                Cancela = entidad.Cancela,
            };

            _context.tb_facturacabe.Add(facturaNueva);
            _context.SaveChanges();

            return facturaNueva;
        }

        public TbFacturaCabe EditarFactura(int IdPedidoCabe, FacturaCabeDTO entidad)
        {
            var idCliente = _context.tb_clientes
                            .Where(x => x.NombreCia.Contains(entidad.NombreCliente))
                            .Select(x => x.IdCliente).FirstOrDefault();

            var idEmpleado = _context.tb_empleados
                             .Where(x => x.Nombre.Contains(entidad.NombreEmpleado))
                             .Select(x => x.IdEmpleado).FirstOrDefault();

            var facturaEditar = _context.tb_facturacabe.FirstOrDefault(x => x.IdPedidoCabe == IdPedidoCabe);

            if (facturaEditar != null)
            {
                facturaEditar.IdCliente = idCliente;
                facturaEditar.IdEmpleado = idEmpleado;
                facturaEditar.FechaFactura = entidad.FechaFactura;
                facturaEditar.Monto = entidad.Monto;
                facturaEditar.IGV = entidad.IGV;
                facturaEditar.Cancela = entidad.Cancela;
            }
            else
            {
                throw new InvalidOperationException($"No se encontraron facturas con el id del pedido");
            }

            _context.tb_facturacabe.Update(facturaEditar);
            _context.SaveChanges();

            return (facturaEditar);
        }

        public void EliminarFactura(int idFacturaCabe)
        {
            var facturaEliminar = _context.tb_facturacabe.FirstOrDefault(x => x.IdFacturaCabe == idFacturaCabe);

            if (facturaEliminar != null)
            {
                _context.tb_facturacabe.Remove(facturaEliminar);
                _context.SaveChanges();
            }
        }
    }
}
