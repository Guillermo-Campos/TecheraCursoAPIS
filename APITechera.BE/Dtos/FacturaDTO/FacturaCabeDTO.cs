namespace APITechera.BE.Dtos.FacturaDTO
{
    public class FacturaCabeDTO
    {
        public string NombreCliente { get; set; }
        public string NombreEmpleado { get; set; }
        public int IdPedidoCabe { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal Monto { get; set; }
        public decimal IGV { get; set; }
        public string Cancela { get; set; }
    }
}
