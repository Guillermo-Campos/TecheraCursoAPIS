using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITechera.BE.Models
{
    [Table("tb_pedidosdeta")]
    public class TbPedidoDeta
    {
        [Key]
        public int IdPedidoDeta { get; set; }
        public int IdPedidoCabe { get; set; }
        public int IdProducto { get; set; }
        public decimal PrecioUnidad { get; set; }
        public Int16 Cantidad { get; set; }
        public double Descuento { get; set; }
    }
}
