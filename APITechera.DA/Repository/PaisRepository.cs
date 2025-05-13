using APITechera.BE.Models;
using APITechera.DA.Data;
using APITechera.DA.IRepository;

namespace APITechera.DA.Repository
{
    public class PaisRepository : IPaisRepository
    {
        private ApplicationDbContext _context;

        public PaisRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TbPais> ListarPaises()
        {
            return _context.tb_paises.ToList();
        }

        public IEnumerable<string> PaisPorNombre(string nombrePais)
        {
            var pais = _context.tb_paises.Where(x => x.NombrePais.Contains(nombrePais)).Select(x => x.NombrePais);

            if(pais != null)
            {
                return pais;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró un pais con el nombre {nombrePais}");
            }
        }

        public TbPais CrearPais(string nombrePais)
        {
            var paisNuevo = new TbPais()
            {
                NombrePais = nombrePais,
            };

            _context.tb_paises.Add(paisNuevo);
            _context.SaveChanges();

            return paisNuevo;
        }

        public TbPais EditarPais(string nombrePais, string nuevoNombrePais)
        {
            var paisEditar = _context.tb_paises.FirstOrDefault(x => x.NombrePais.Contains(nombrePais));

            if(paisEditar != null)
            {
                paisEditar.NombrePais = nuevoNombrePais;
            }
            else
            {
                throw new InvalidOperationException($"No se encontró un pais con el nombre {nombrePais}");
            }

            _context.tb_paises.Update(paisEditar);
            _context.SaveChanges();

            return paisEditar;
        }

        public void EliminarPais(string nombrePais)
        {
            var paisEliminar = _context.tb_paises.FirstOrDefault(x => x.NombrePais.Contains(nombrePais));

            if(paisEliminar != null)
            {
                _context.tb_paises.Remove(paisEliminar);
                _context.SaveChanges();
            }
        }
    }
}
