using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITechera.BE.Models
{
    [Table("tb_usuarios")]
    public class TbUsuario
    {
        [Key]
        public int IdEmpleado { get; set; }
        public string Logon { get; set; }
        public string Clave { get; set; }
    }
}
