using ApiWebSeguros.Dominio;
using Microsoft.EntityFrameworkCore;

namespace ApiWebSeguros.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Poliza> Polizas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<EstadoCivil> EstadosCiviles  { get; set; }

        public DbSet<Producto> Productos { get; set; }

         public DbSet<Rol> Roles  { get; set; }

        public DbSet<Ramo> Ramos { get; set; }
        public DbSet<WayPay> WayPays  { get; set; }

        public DbSet<TipoRoles> TipoRoles { get; set; }
    }
}