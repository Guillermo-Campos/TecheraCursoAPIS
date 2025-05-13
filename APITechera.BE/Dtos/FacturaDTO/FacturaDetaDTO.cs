namespace APITechera.BE.Dtos.FacturaDTO
{
    public class FacturaDetaDTO
    {
        public int IdFacturaCabe { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioUnidad { get; set; }
        public Int16 Cantidad { get; set; }
    }
}
