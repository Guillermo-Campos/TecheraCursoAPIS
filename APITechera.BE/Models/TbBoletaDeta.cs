using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITechera.BE.Models
{
    [Table("tb_boletadeta")]
    public class TbBoletaDeta
    {
        [Key]
        public int IdBoletaDeta { get; set; }
        public int IdBoletaCabe { get; set; }
        public int IdProducto { get; set; }
        public decimal PrecioUnidad { get; set; }
        public Int16 Cantidad { get; set; }
    }
}
