using APITechera.BE.Dtos.BoletaDTO;
using APITechera.BE.Models;
using APITechera.BL.IServices;
using APITechera.DA.IRepository;

namespace APITechera.BL.Services
{
    public class BoletaCabeService : IBoletaCabeService
    {
        private readonly IBoletaCabeRepository _boletaCabeRepository;

        public BoletaCabeService(IBoletaCabeRepository boletaCabeRepository)
        {
            _boletaCabeRepository = boletaCabeRepository;
        }

        public IEnumerable<TbBoletaCabe> ListarBoletas()
        {
            return _boletaCabeRepository.ListarBoletas();
        }

        public IEnumerable<BoletaCabeDTO> ListarBoletasPorCliente(string nombreCliente)
        {
            return _boletaCabeRepository.ListarBoletasPorCliente(nombreCliente);
        }

        public IEnumerable<BoletaCabeDTO> ListarBoletasPorEmpleado(string nombreEmpleado)
        {
            return _boletaCabeRepository.ListarBoletasPorEmpleado(nombreEmpleado);
        }

        public IEnumerable<BoletaCabeDTO> ListarBoletasPorPedido(int idPedido)
        {
            return _boletaCabeRepository.ListarBoletasPorPedido(idPedido);
        }

        public TbBoletaCabe CrearBoletaCabe(BoletaCabeDTO entidad)
        {
            return _boletaCabeRepository.CrearBoletaCabe(entidad);
        }

        public TbBoletaCabe EditarBoletaCabe(int pedido, BoletaCabeDTO entidad)
        {
            return _boletaCabeRepository.EditarBoletaCabe(pedido, entidad);
        }

        public void EliminarBoletaCabe(int pedido)
        {
            _boletaCabeRepository.EliminarBoletaCabe(pedido);
        }
    }
}
