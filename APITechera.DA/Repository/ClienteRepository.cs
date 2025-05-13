using APITechera.BE.Dtos.ClienteDTO;
using APITechera.BE.Models;
using APITechera.DA.Data;
using APITechera.DA.IRepository;

namespace APITechera.DA.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TbCliente> ListarClientes()
        {
            return _context.tb_clientes.ToList();
        }

        public IEnumerable<ClienteDTO> ClientePorNombre(string nombreCia)
        {
            var cliente = (from c in _context.tb_clientes
                              join p in _context.tb_paises on c.IdPais equals p.IdPais
                              where c.NombreCia.Contains(nombreCia)
                              select new ClienteDTO
                              {
                                  NombreCia = c.NombreCia,
                                  Direccion = c.Direccion,
                                  NombrePais = p.NombrePais,
                                  Telefono = c.Telefono
                              });

            if(cliente != null )
            {
                return cliente;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró un cliente con el nombre {nombreCia}");
            }
        }

        public IEnumerable<ClienteDTO> ClientesPorPais(string pais)
        {
            var cliente = (from c in _context.tb_clientes
                           join p in _context.tb_paises on c.IdPais equals p.IdPais
                           where p.NombrePais.Contains(pais)
                           select new ClienteDTO
                           {
                               NombreCia = c.NombreCia,
                               Direccion = c.Direccion,
                               NombrePais = p.NombrePais,
                               Telefono = c.Telefono
                           });

            if (cliente != null)
            {
                return cliente.ToList();
            }
            else
            {
                throw new InvalidOperationException($"No se encontraron clientes en el pais {pais}");
            }
        }

        public TbCliente CrearCliente(TbCliente entidad)
        {
            var clienteNuevo =  new TbCliente() 
            { 
              NombreCia = entidad.NombreCia,
              Direccion = entidad.Direccion,
              IdPais = entidad.IdPais,
              Telefono = entidad.Telefono
            };

            _context.tb_clientes.Add(clienteNuevo);
            _context.SaveChanges();

            return clienteNuevo;
        }

        public TbCliente EditarCliente(string nombreCia, TbCliente entidad)
        {
            var clienteEditar = _context.tb_clientes.FirstOrDefault(x => x.NombreCia.Contains(nombreCia));

            if(clienteEditar != null)
            {
                clienteEditar.NombreCia = entidad.NombreCia;
                clienteEditar.Direccion = entidad.Direccion;
                clienteEditar.IdPais = entidad.IdPais;
                clienteEditar.Telefono = entidad.Telefono;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró una cliente con el nombre {nombreCia}");
            }

            _context.tb_clientes.Update(clienteEditar);
            _context.SaveChanges();

            return clienteEditar;
        }

        public void EliminarCliente(string nombreCia)
        {
            var clienteEliminar = _context.tb_clientes.FirstOrDefault(x => x.NombreCia.Contains(nombreCia));

            if(clienteEliminar != null)
            {
                _context.tb_clientes.Remove(clienteEliminar);
                _context.SaveChanges();
            }
        }
    }
}
