using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITechera.BE.Models
{
    [Table("tb_proveedores")]
    public class TbProveedor
    {
        [Key]
        public int IdProveedor { get; set; }
        public string NombreCia { get; set; }
        public string NombreContacto { get; set; }
        public string CargoContacto { get; set; }
        public string Direccion { get; set; }
        public int IdPais { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
    }
}
