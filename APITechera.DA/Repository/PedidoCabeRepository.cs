using APITechera.BE.Dtos.PedidoDTO;
using APITechera.BE.Models;
using APITechera.DA.Data;
using APITechera.DA.IRepository;

namespace APITechera.DA.Repository
{
    public class PedidoCabeRepository : IPedidoCabeRepository
    {
        private readonly ApplicationDbContext _context;

        public PedidoCabeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TbPedidoCabe> ListarPedidos()
        {
            return _context.tb_pedidoscabe.ToList();
        }

        public IEnumerable<PedidoCabeDTO> ListarPedidosPorCliente(string nombreCliente)
        {
            var pedido = (from p in _context.tb_pedidoscabe
                          join c in _context.tb_clientes on p.IdCliente equals c.IdCliente
                          join e in _context.tb_empleados on p.IdEmpleado equals e.IdEmpleado
                          where c.NombreCia.Contains(nombreCliente)
                          select new PedidoCabeDTO()
                          {
                              NombreCliente = c.NombreCia,
                              NombreEmpleado = e.Nombre,
                              FechaPedido = p.FechaPedido,
                              FechaEntrega = p.FechaEntrega,
                              FechaEnvio = p.FechaEnvio,
                              Envio = p.Envio,
                              Cargo = p.Cargo,
                              Destinatario = p.Destinatario,
                              DireccionDestinatario = p.DireccionDestinatario,
                              CiudadDestinatario = p.CiudadDestinatario,
                              RegionDestinatario = p.RegionDestinatario,
                              CodPostalDestinatario = p.CodPostalDestinatario,
                              PaisDestinatario = p.PaisDestinatario
                          });

            if(pedido != null)
            {
                return pedido.ToList();
            }
            else
            {
                throw new InvalidOperationException($"No se encontró pedidos del cliente {nombreCliente}");
            }
        }

        public IEnumerable<PedidoCabeDTO> ListarPedidosPorEmpleados(string nombreEmpleado)
        {
            var pedido = (from p in _context.tb_pedidoscabe
                          join c in _context.tb_clientes on p.IdCliente equals c.IdCliente
                          join e in _context.tb_empleados on p.IdEmpleado equals e.IdEmpleado
                          where e.Nombre.Contains(nombreEmpleado)
                          select new PedidoCabeDTO()
                          {
                              NombreCliente = c.NombreCia,
                              NombreEmpleado = e.Nombre,
                              FechaPedido = p.FechaPedido,
                              FechaEntrega = p.FechaEntrega,
                              FechaEnvio = p.FechaEnvio,
                              Envio = p.Envio,
                              Cargo = p.Cargo,
                              Destinatario = p.Destinatario,
                              DireccionDestinatario = p.DireccionDestinatario,
                              CiudadDestinatario = p.CiudadDestinatario,
                              RegionDestinatario = p.RegionDestinatario,
                              CodPostalDestinatario = p.CodPostalDestinatario,
                              PaisDestinatario = p.PaisDestinatario
                          });

            if (pedido != null)
            {
                return pedido.ToList();
            }
            else
            {
                throw new InvalidOperationException($"No se encontró pedidos del empleado {nombreEmpleado}");
            }
        }

        public TbPedidoCabe CrearPedido(PedidoCabeDTO entidad)
        {
            var idCliente = _context.tb_clientes
                            .Where(x => x.NombreCia.Contains(entidad.NombreCliente))
                            .Select(x => x.IdCliente).FirstOrDefault();

            var idEmpleado = _context.tb_empleados
                             .Where(x => x.Nombre.Contains(entidad.NombreEmpleado))
                             .Select(x => x.IdEmpleado).FirstOrDefault();
        
            var pedidoCrear = new TbPedidoCabe() 
            { 
                IdCliente = idCliente,
                IdEmpleado = idEmpleado,
                FechaPedido = entidad.FechaPedido,
                FechaEntrega = entidad.FechaEntrega,
                FechaEnvio = entidad.FechaEnvio,
                Envio = entidad.Envio,
                Cargo = entidad.Cargo,
                Destinatario = entidad.Destinatario,
                DireccionDestinatario = entidad.DireccionDestinatario,
                CiudadDestinatario = entidad.CiudadDestinatario,
                RegionDestinatario = entidad.RegionDestinatario,
                CodPostalDestinatario = entidad.CodPostalDestinatario,
                PaisDestinatario = entidad.PaisDestinatario,
            };

            _context.tb_pedidoscabe.Add(pedidoCrear);
            _context.SaveChanges();

            return pedidoCrear;
        }

        public TbPedidoCabe EditarPedido(int idPedidoCabe, PedidoCabeDTO entidad)
        {
            var idCliente = _context.tb_clientes
                            .Where(x => x.NombreCia.Contains(entidad.NombreCliente))
                            .Select(x => x.IdCliente).FirstOrDefault();

            var idEmpleado = _context.tb_empleados
                             .Where(x => x.Nombre.Contains(entidad.NombreEmpleado))
                             .Select(x => x.IdEmpleado).FirstOrDefault();

            var pedidoEditar = _context.tb_pedidoscabe
                               .FirstOrDefault(x => x.IdPedidoCabe == idPedidoCabe);

            if (pedidoEditar != null)
            {
                pedidoEditar.IdCliente = idCliente;
                pedidoEditar.IdEmpleado = idEmpleado;
                pedidoEditar.FechaPedido = entidad.FechaPedido;
                pedidoEditar.FechaEntrega = entidad.FechaEntrega;
                pedidoEditar.FechaEnvio = entidad.FechaEnvio;
                pedidoEditar.Envio = entidad.Envio;
                pedidoEditar.Cargo = entidad.Cargo;
                pedidoEditar.Destinatario = entidad.Destinatario;
                pedidoEditar.DireccionDestinatario = entidad.DireccionDestinatario;
                pedidoEditar.CiudadDestinatario = entidad.CiudadDestinatario;
                pedidoEditar.RegionDestinatario = entidad.RegionDestinatario;
                pedidoEditar.CodPostalDestinatario = entidad.CodPostalDestinatario;
                pedidoEditar.PaisDestinatario = entidad.PaisDestinatario;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró pedidos con el Id proporcionado");
            }

            _context.tb_pedidoscabe.Update(pedidoEditar);
            _context.SaveChanges();

            return pedidoEditar;
        }

        public void EliminarPedido(int idPedidoCabe)
        {
            var pedidoEliminar = _context.tb_pedidoscabe
                               .FirstOrDefault(x => x.IdPedidoCabe == idPedidoCabe);

            if(pedidoEliminar != null)
            {
                _context.tb_pedidoscabe.Remove(pedidoEliminar);
                _context.SaveChanges();
            }
        }
    }
}
