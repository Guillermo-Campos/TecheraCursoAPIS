using APITechera.BE.Models;

namespace APITechera.BL.IServices
{
    public interface IPaisService
    {
        IEnumerable<TbPais> ListarPaises();

        IEnumerable<string> PaisPorNombre(string nombrePais);

        TbPais CrearPais(string nombrePais);

        TbPais EditarPais(string nombrePais, string nuevoNombrePais);

        void EliminarPais(string nombrePais);
    }
}
