using APITechera.BE.Dtos.BoletaDTO;
using APITechera.BE.Models;
using APITechera.DA.Data;
using APITechera.DA.IRepository;

namespace APITechera.DA.Repository
{
    public class BoletaDetaRepository : IBoletaDetaRepository
    {
        private readonly ApplicationDbContext _context;

        public BoletaDetaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TbBoletaDeta> ListarBoletas()
        {
            return _context.tb_boletadeta.ToList();
        }

        public IEnumerable<BoletaDetaDTO> ListarBoletaPorNombreProducto(string nombreProducto)
        {
            var boleta = (from b in _context.tb_boletadeta
                          join p in _context.tb_productos on b.IdProducto equals p.IdProducto
                          where p.NombreProducto.Contains(nombreProducto)
                          select new BoletaDetaDTO()
                          {
                              IdBoletaCabe = b.IdBoletaCabe,
                              NombreProducto = p.NombreProducto,
                              PrecioUnidad = b.PrecioUnidad,
                              Cantidad = b.Cantidad,
                          });

            if(boleta != null)
            {
                return boleta.ToList();
            }
            else
            {
                throw new InvalidOperationException($"No se encontró boletas con el producto {nombreProducto}");
            }
        }

        public TbBoletaDeta CrearBoletaDeta(BoletaDetaDTO entidad)
        {
            var idProducto = _context.tb_productos
                            .Where(x => x.NombreProducto.Contains(entidad.NombreProducto))
                            .Select(x => x.IdProducto).FirstOrDefault();

            if(idProducto != null)
            {
                throw new InvalidOperationException($"No se encontró boletas con el producto {entidad.NombreProducto}");
            }

            var boletaNuevo = new TbBoletaDeta() 
            {
                IdBoletaCabe = entidad.IdBoletaCabe,
                IdProducto = idProducto,
                PrecioUnidad = entidad.PrecioUnidad,
                Cantidad = entidad.Cantidad,
            };

            _context.tb_boletadeta.Add(boletaNuevo);
            _context.SaveChanges();

            return boletaNuevo;
        }

        public TbBoletaDeta EditarBoletaDeta(string nombreProducto, BoletaDetaDTO entidad)
        {
            var idProducto = _context.tb_productos
                            .Where(x => x.NombreProducto.Contains(entidad.NombreProducto))
                            .Select(x => x.IdProducto).FirstOrDefault();

            if (idProducto == null)
            {
                throw new InvalidOperationException($"No se encontró un producto con el nombre {nombreProducto}");
            }

            var boletaEditar = _context.tb_boletadeta.FirstOrDefault(x => x.IdProducto == idProducto);

            boletaEditar.IdBoletaCabe = entidad.IdBoletaCabe;
            boletaEditar.PrecioUnidad = entidad.PrecioUnidad;
            boletaEditar.Cantidad = entidad.Cantidad;

            
            _context.SaveChanges();

            return boletaEditar;
        }

        public void EliminarBoletaDeta(string nombreProducto)
        {
            var idProducto = _context.tb_productos
                            .Where(x => x.NombreProducto.Contains(nombreProducto))
                            .Select(x => x.IdProducto).FirstOrDefault();

            if (idProducto != null)
            {
                var productoEliminar = _context.tb_boletadeta.FirstOrDefault(x => x.IdProducto == idProducto);

                _context.tb_boletadeta.Remove(productoEliminar);
                _context.SaveChanges();
            }
        }
    }
}
