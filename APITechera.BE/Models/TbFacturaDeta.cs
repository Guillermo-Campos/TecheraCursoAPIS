using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITechera.BE.Models
{
    [Table("tb_facturasdeta")]
    public class TbFacturaDeta
    {
        [Key]
        public int IdFacturaDeta { get; set; }
        public int IdFacturaCabe { get; set; }
        public int IdProducto { get; set; }
        public decimal PrecioUnidad { get; set; }
        public Int16 Cantidad { get; set; }
    }
}
