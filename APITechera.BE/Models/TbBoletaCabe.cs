using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITechera.BE.Models
{
    [Table("tb_boletacabe")]
    public class TbBoletaCabe
    {
        [Key]
        public int IdBoletaCabe { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public int IdPedidoCabe { get; set; }
        public DateTime FechaBoleta { get; set; }
        public decimal Monto { get; set; }
        public string Cancela { get; set; }
    }
}
