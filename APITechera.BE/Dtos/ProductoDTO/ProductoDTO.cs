namespace APITechera.BE.Dtos.ProductDTO
{
    public class ProductoDTO
    {
        public string NombreProducto { get; set; }
        public string NombreProveedor { get; set; }
        public string NombreCategoria { get; set; }
        public string CantidadPorUnidad { get; set; }
        public decimal PrecioUnidad { get; set; }
        public Int16 UnidadesEnExistencia { get; set; }
        public Int16 UnidadesEnPedido { get; set; }
    }
}
