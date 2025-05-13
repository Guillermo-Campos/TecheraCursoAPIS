namespace APITechera.BE.Dtos.PedidoDTO
{
    public class PedidoDetaDTO
    {
        public int IdPedidoCabe { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioUnidad { get; set; }
        public Int16 Cantidad { get; set; }
        public double Descuento { get; set; }
    }
}
