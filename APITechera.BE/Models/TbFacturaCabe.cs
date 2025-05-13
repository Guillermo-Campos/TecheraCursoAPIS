using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITechera.BE.Models
{
    [Table("tb_facturacabe")]
    public class TbFacturaCabe
    {
        [Key]
        public int IdFacturaCabe { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public int IdPedidoCabe { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal Monto { get; set; }
        public decimal IGV { get; set; }
        public string Cancela { get; set; }
    }
}
