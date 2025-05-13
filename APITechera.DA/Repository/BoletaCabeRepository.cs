using APITechera.BE.Dtos.BoletaDTO;
using APITechera.BE.Models;
using APITechera.DA.Data;
using APITechera.DA.IRepository;

namespace APITechera.DA.Repository
{
    public class BoletaCabeRepository : IBoletaCabeRepository
    {
        private readonly ApplicationDbContext _context;

        public BoletaCabeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TbBoletaCabe> ListarBoletas()
        {
            return _context.tb_boletacabe.ToList();
        }

        public IEnumerable<BoletaCabeDTO> ListarBoletasPorCliente(string nombreCliente)
        {
            var boleta = (from b in _context.tb_boletacabe
                          join c in _context.tb_clientes on b.IdCliente equals c.IdCliente
                          join e in _context.tb_empleados on b.IdEmpleado equals e.IdEmpleado
                          where c.NombreCia.Contains(nombreCliente)
                          select new BoletaCabeDTO()
                          {
                            NombreCliente = c.NombreCia,
                            Empleado = e.Nombre,
                            PedidoCabe = b.IdPedidoCabe,
                            FechaBoleta = b.FechaBoleta,
                            Monto = b.Monto,
                            Cancela = b.Cancela,
                          });

            if(boleta != null)
            {
                return boleta.ToList();
            }
            else
            {
                throw new InvalidOperationException($"No se encontró boletas del cliente {nombreCliente}");
            }
        }

        public IEnumerable<BoletaCabeDTO> ListarBoletasPorEmpleado(string nombreEmpleado)
        {
            var boleta = (from b in _context.tb_boletacabe
                          join c in _context.tb_clientes on b.IdCliente equals c.IdCliente
                          join e in _context.tb_empleados on b.IdEmpleado equals e.IdEmpleado
                          where e.Nombre.Contains(nombreEmpleado)
                          select new BoletaCabeDTO()
                          {
                              NombreCliente = c.NombreCia,
                              Empleado = e.Nombre,
                              PedidoCabe = b.IdPedidoCabe,
                              FechaBoleta = b.FechaBoleta,
                              Monto = b.Monto,
                              Cancela = b.Cancela,
                          });

            if (boleta != null)
            {
                return boleta.ToList();
            }
            else
            {
                throw new InvalidOperationException($"No se encontró boletas del empleado {nombreEmpleado}");
            }
        }

        public IEnumerable<BoletaCabeDTO> ListarBoletasPorPedido(int idPedido)
        {
            var boleta = (from b in _context.tb_boletacabe
                          join c in _context.tb_clientes on b.IdCliente equals c.IdCliente
                          join e in _context.tb_empleados on b.IdEmpleado equals e.IdEmpleado
                          join p in _context.tb_pedidosdeta on b.IdPedidoCabe equals p.IdPedidoCabe
                          where p.IdPedidoCabe == idPedido
                          select new BoletaCabeDTO()
                          {
                              NombreCliente = c.NombreCia,
                              Empleado = e.Nombre,
                              PedidoCabe = p.IdPedidoCabe,
                              FechaBoleta = b.FechaBoleta,
                              Monto = b.Monto,
                              Cancela = b.Cancela,
                          });

            if (boleta != null)
            {
                return boleta.ToList();
            }
            else
            {
                throw new InvalidOperationException($"No se encontró boletas con el pedido {idPedido}");
            }
        }

        public TbBoletaCabe CrearBoletaCabe(BoletaCabeDTO entidad)
        {
            var idCliente = _context.tb_clientes
                .Where(x => x.NombreCia.Contains(entidad.NombreCliente))
                .Select(x => x.IdCliente).FirstOrDefault();

            var idEmpleado = _context.tb_empleados
                .Where(x => x.Nombre.Contains(entidad.Empleado))
                .Select(x => x.IdEmpleado).FirstOrDefault();

            var boletaNueva = new TbBoletaCabe()
            {
                IdCliente = idCliente,
                IdEmpleado = idEmpleado,
                IdPedidoCabe = entidad.PedidoCabe,
                FechaBoleta = entidad.FechaBoleta,
                Monto = entidad.Monto,
                Cancela = entidad.Cancela
            };

            _context.tb_boletacabe.Add(boletaNueva);
            _context.SaveChanges();

            return boletaNueva;
        }

        public TbBoletaCabe EditarBoletaCabe(int idPedido, BoletaCabeDTO entidad)
        {
            var idCliente = _context.tb_clientes
                            .Where(x => x.NombreCia.Contains(entidad.NombreCliente))
                            .Select(x => x.IdCliente).FirstOrDefault();

            var idEmpleado = _context.tb_empleados
                            .Where(x => x.Nombre.Contains(entidad.Empleado))
                            .Select(x => x.IdEmpleado).FirstOrDefault();

            var boletaEditar = _context.tb_boletacabe.FirstOrDefault(x => x.IdPedidoCabe == entidad.PedidoCabe);

            if (boletaEditar != null)
            {
                boletaEditar.IdCliente = idCliente;
                boletaEditar.IdEmpleado = idEmpleado;
                boletaEditar.FechaBoleta = entidad.FechaBoleta;
                boletaEditar.Monto = entidad.Monto;
                boletaEditar.Cancela = entidad.Cancela;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró boletas con el pedido {idPedido}");
            }

            _context.tb_boletacabe.Update(boletaEditar);
            _context.SaveChanges();

            return boletaEditar;
        }

        public void EliminarBoletaCabe(int pedido)
        {
            var boletaEliminar = _context.tb_boletacabe
                                .FirstOrDefault(x => x.IdPedidoCabe == pedido);

            if(boletaEliminar != null)
            {
                _context.tb_boletacabe.Remove(boletaEliminar);
                _context.SaveChanges();
            }
        }
    }
}
