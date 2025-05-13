namespace APITechera.BE.Dtos.BoletaDTO
{
    public class BoletaCabeDTO
    {
        public string NombreCliente { get; set; }
        public string Empleado { get; set; }
        public int PedidoCabe { get; set; }
        public DateTime FechaBoleta { get; set; }
        public decimal Monto { get; set; }
        public string Cancela { get; set; }
    }
}
