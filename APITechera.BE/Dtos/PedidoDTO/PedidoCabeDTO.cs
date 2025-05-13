namespace APITechera.BE.Dtos.PedidoDTO
{
    public class PedidoCabeDTO
    {
        public string NombreCliente { get; set; }
        public string NombreEmpleado { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string Envio { get; set; }
        public decimal Cargo { get; set; }
        public string Destinatario { get; set; }
        public string DireccionDestinatario { get; set; }
        public string CiudadDestinatario { get; set; }
        public string RegionDestinatario { get; set; }
        public string CodPostalDestinatario { get; set; }
        public string PaisDestinatario { get; set; }
    }
}
