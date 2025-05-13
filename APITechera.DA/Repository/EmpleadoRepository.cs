using APITechera.BE.Dtos.EmpleadoDTO;
using APITechera.BE.Models;
using APITechera.DA.Data;
using APITechera.DA.IRepository;

namespace APITechera.DA.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TbEmpleado> ListarEmpleados()
        {
            return _context.tb_empleados.ToList();
        }

        public IEnumerable<EmpleadoDTO> EmpleadoPorNombre(string nombre, string apellidos)
        {
            var usuario = _context.tb_empleados
                .Where(x => x.Nombre.Contains(nombre) && x.Apellidos.Contains(apellidos))
                .Select(x => new EmpleadoDTO()
                {
                    Apellidos = x.Apellidos,
                    Nombre = x.Nombre,
                    Cargo = x.Cargo,
                    Tratamiento = x.Tratamiento,
                    FechaNacimiento = x.FechaNacimiento,
                    FechaContratacion = x.FechaContratacion,
                    Direccion = x.Direccion,
                    Ciudad = x.Ciudad,
                    Region = x.Region,
                    CodPostal = x.CodPostal,
                    Pais = x.Pais,
                    TelDomicilio = x.TelDomicilio,
                    Extension = x.Extension,
                    Foto = x.Foto,
                    Notas = x.Notas,
                    Jefe = x.Jefe,
                });

            if(usuario != null)
            {
                return usuario;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró un empleado con el nombre {nombre}");
            }
        }

        public IEnumerable<EmpleadoDTO> EmpleadosPorCargo(string cargo)
        {
            var usuario = _context.tb_empleados
                .Where(x => x.Cargo.Contains(cargo))
                .Select(x => new EmpleadoDTO()
                {
                    Apellidos = x.Apellidos,
                    Nombre = x.Nombre,
                    Cargo = x.Cargo,
                    Tratamiento = x.Tratamiento,
                    FechaNacimiento = x.FechaNacimiento,
                    FechaContratacion = x.FechaContratacion,
                    Direccion = x.Direccion,
                    Ciudad = x.Ciudad,
                    Region = x.Region,
                    CodPostal = x.CodPostal,
                    Pais = x.Pais,
                    TelDomicilio = x.TelDomicilio,
                    Extension = x.Extension,
                    Foto = x.Foto,
                    Notas = x.Notas,
                    Jefe = x.Jefe,
                }).ToList();

            if(usuario != null)
            {
                return usuario;
            }
            else
            {
                throw new InvalidOperationException($"No se encontraron empleados con el cargo de {cargo}");
            }
        }

        public TbEmpleado RegistrarEmpleado(EmpleadoDTO entidad)
        {
            var empleadoNuevo = new TbEmpleado() 
            {
                Apellidos = entidad.Apellidos,
                Nombre = entidad.Nombre,
                Cargo = entidad.Cargo,
                Tratamiento = entidad.Tratamiento,
                FechaNacimiento = entidad.FechaNacimiento,
                FechaContratacion = entidad.FechaContratacion,
                Direccion = entidad.Direccion,
                Ciudad = entidad.Ciudad,
                Region = entidad.Region,
                CodPostal = entidad.CodPostal,
                Pais = entidad.Pais,
                TelDomicilio = entidad.TelDomicilio,
                Extension = entidad.Extension,
                Foto = entidad.Foto,
                Notas = entidad.Notas,
                Jefe = entidad.Jefe
            };

            _context.tb_empleados.Add(empleadoNuevo);
            _context.SaveChanges();

            return empleadoNuevo;
        }

        public TbEmpleado EditarEmpleado(string nombre, string apellidos, EmpleadoDTO entidad)
        {
            var empleadoEditar = _context.tb_empleados.FirstOrDefault(x => x.Nombre.Contains(nombre) && x.Apellidos.Contains(apellidos));

            if (empleadoEditar == null)
            {
                empleadoEditar.Apellidos = entidad.Apellidos;
                empleadoEditar.Nombre = entidad.Nombre;
                empleadoEditar.Cargo = entidad.Cargo;
                empleadoEditar.Tratamiento = entidad.Tratamiento;
                empleadoEditar.FechaNacimiento = entidad.FechaNacimiento;
                empleadoEditar.FechaContratacion = entidad.FechaContratacion;
                empleadoEditar.Direccion = entidad.Direccion;
                empleadoEditar.Ciudad = entidad.Ciudad;
                empleadoEditar.Region = entidad.Region;
                empleadoEditar.CodPostal = entidad.CodPostal;
                empleadoEditar.Pais = entidad.Pais;
                empleadoEditar.TelDomicilio = entidad.TelDomicilio;
                empleadoEditar.Extension = entidad.Extension;
                empleadoEditar.Foto = entidad.Foto;
                empleadoEditar.Notas = entidad.Notas;
                empleadoEditar.Jefe = entidad.Jefe;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró un empleado con el nombre {nombre}");
            }

            _context.tb_empleados.Update(empleadoEditar);
            _context.SaveChanges();

            return empleadoEditar;
        }

        public void EliminarEmpleado(string nombres, string apellidos)
        {
            var empleadoEliminar = _context.tb_empleados.FirstOrDefault(x => x.Nombre.Contains(nombres) && x.Apellidos.Contains(apellidos));

            if(empleadoEliminar != null)
            {
                _context.tb_empleados.Remove(empleadoEliminar);
                _context.SaveChanges();
            }
        }
    }
}
