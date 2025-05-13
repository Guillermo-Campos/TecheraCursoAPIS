using APITechera.BL.IServices;
using APITechera.BL.Services;
using APITechera.DA.Data;
using APITechera.DA.IRepository;
using APITechera.DA.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IPaisRepository, PaisRepository>();
builder.Services.AddScoped<IPaisService, PaisService>();
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IBoletaDetaRepository, BoletaDetaRepository>();
builder.Services.AddScoped<IBoletaDetaService, BoletaDetaService>();
builder.Services.AddScoped<IBoletaCabeRepository, BoletaCabeRepository>();
builder.Services.AddScoped<IBoletaCabeService, BoletaCabeService>();
builder.Services.AddScoped<IPedidoCabeRepository, PedidoCabeRepository>();
builder.Services.AddScoped<IPedidoCabeService, PedidoCabeService>();
builder.Services.AddScoped<IPedidoDetaRepository, PedidoDetaRepository>();
builder.Services.AddScoped<IPedidoDetaService, PedidoDetaService>();
builder.Services.AddScoped<IFacturaCabeRepository, FacturaCabeRepository>();
builder.Services.AddScoped<IFacturaCabeService, FacturaCabeService>();
builder.Services.AddScoped<IFacturaDetaRepository, FacturaDetaRepository>();
builder.Services.AddScoped<IFacturaDetaService, FacturaDetaService>();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DBVentas")));

var app = builder.Build();

//// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
