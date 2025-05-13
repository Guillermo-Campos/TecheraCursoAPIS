using APITechera.BE.Dtos.ProveedorDTO;
using APITechera.BE.Models;
using APITechera.DA.Data;
using APITechera.DA.IRepository;

namespace APITechera.DA.Repository
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly ApplicationDbContext _context;

        public ProveedorRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public IEnumerable<TbProveedor> ListarProveedores()
        {
            return _context.tb_proveedores.ToList();
        }

        public IEnumerable<ProveedorDTO> ProveedoresPorCia(string nombreCia)
        {
            var proveedor = _context.tb_proveedores
                .Where(X => X.NombreCia.Contains(nombreCia))
                .Select(x => new ProveedorDTO
                {
                    NombreCia = x.NombreCia,
                    NombreContacto = x.NombreContacto,
                    Direccion = x.Direccion,
                    IdPais = x.IdPais,
                    Telefono = x.Telefono,
                    Fax = x.Fax,
                }).ToList();

            if (proveedor != null)
            {
                return proveedor;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró un proveedor con el nombre {nombreCia}");
            }
        }

        public IEnumerable<ProveedorDTO> ProveedorPorNombre(string nombreContacto)
        {
            var proveedor = _context.tb_proveedores
                .Where(X => X.NombreContacto.Contains(nombreContacto))
                .Select(x => new ProveedorDTO
                {
                    NombreCia = x.NombreCia,
                    NombreContacto = x.NombreContacto,
                    Direccion = x.Direccion,
                    IdPais = x.IdPais,
                    Telefono = x.Telefono,
                    Fax = x.Fax,
                });

            if (proveedor != null)
            {
                return proveedor;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró un proveedor con el nombre {nombreContacto}");
            }
        }

        public TbProveedor CrearProveedor(ProveedorDTO entidad)
        {
            var proveedorNuevo = new TbProveedor()
            {
                NombreCia = entidad.NombreCia,
                NombreContacto = entidad.NombreContacto,
                CargoContacto = entidad.CargoContacto,
                Direccion = entidad.Direccion,
                IdPais = entidad.IdPais,
                Telefono = entidad.Telefono,
                Fax = entidad.Fax,
            };

            _context.tb_proveedores.Add(proveedorNuevo);
            _context.SaveChanges();
            return proveedorNuevo;
        }

        public TbProveedor EditarProveedor(string nombreCia, ProveedorDTO entidad)
        {
            var proveedorActualizar = _context.tb_proveedores.FirstOrDefault(x => x.NombreCia.Contains(nombreCia));
            if (proveedorActualizar != null)
            {
                proveedorActualizar.NombreCia = entidad.NombreCia;
                proveedorActualizar.NombreContacto = entidad.NombreContacto;
                proveedorActualizar.CargoContacto = entidad.CargoContacto;
                proveedorActualizar.Direccion = entidad.Direccion;
                proveedorActualizar.IdPais = entidad.IdPais;
                proveedorActualizar.Telefono = entidad.Telefono;
                proveedorActualizar.Fax = entidad.Fax;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró un proveedor con el nombre {nombreCia}");
            }

            _context.tb_proveedores.Update(proveedorActualizar);
            _context.SaveChanges();

            return proveedorActualizar;
        }

        public void EliminarProveedor(string nombreCia)
        {
            var proveedorEliminar = _context.tb_proveedores.FirstOrDefault(x => x.NombreCia.Contains(nombreCia));
            if (proveedorEliminar != null)
            {
                _context.tb_proveedores.Remove(proveedorEliminar);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException($"No se encontró un proveedor con el nombre {nombreCia}");
            }
        }
    }
}
