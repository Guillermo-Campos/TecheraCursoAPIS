using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITechera.BE.Models
{
    [Table("tb_clientes")]
    public class TbCliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string NombreCia { get; set; }
        public string Direccion { get; set; }
        public int IdPais { get; set; }
        public string Telefono { get; set; }
    }
}
