using APITechera.BE.Models;
using Microsoft.EntityFrameworkCore;

namespace APITechera.DA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        { 
        }

        public DbSet<TbUsuario> tb_usuarios { get; set; }
        public DbSet<TbProveedor> tb_proveedores { get; set; }
        public DbSet<TbProducto> tb_productos { get; set; }
        public DbSet<TbPedidoDeta> tb_pedidosdeta { get; set; }
        public DbSet<TbPedidoCabe> tb_pedidoscabe { get; set; }
        public DbSet<TbPais> tb_paises { get; set; }
        public DbSet<TbFacturaDeta> tb_facturasdeta { get; set; }
        public DbSet<TbFacturaCabe> tb_facturacabe { get; set; }
        public DbSet<TbEmpleado> tb_empleados { get; set; }
        public DbSet<TbCliente> tb_clientes { get; set; }
        public DbSet<TbCategoria> tb_categorias { get; set; }
        public DbSet<TbBoletaDeta> tb_boletadeta { get; set; }
        public DbSet<TbBoletaCabe> tb_boletacabe { get; set; }
    }
}
