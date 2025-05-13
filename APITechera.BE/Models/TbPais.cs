using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITechera.BE.Models
{
    [Table("tb_paises")]
    public class TbPais
    {
        [Key]
        public int IdPais { get; set; }
        public string NombrePais { get; set; }
    }
}
