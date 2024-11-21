using Microsoft.EntityFrameworkCore;
using ApiWebSeguros.Dominio;

namespace ApiWebSeguros.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("User Id=sys;Password=Bdt24++;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.43.190)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XEPDB1)));DBA Privilege=SYSDBA;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Poliza> Polizas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Ramo> Ramos { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeo de entidades a tablas personalizadas
            modelBuilder.Entity<Cliente>().ToTable("CLIENTES");
            modelBuilder.Entity<Poliza>().ToTable("POLIZA");
            modelBuilder.Entity<Producto>().ToTable("PRODUCTMASTER");
            modelBuilder.Entity<Ramo>().ToTable("BRANCHMASTER");

            base.OnModelCreating(modelBuilder);
        }
    }
}
