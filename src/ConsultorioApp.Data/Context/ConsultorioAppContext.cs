using ConsultorioApp.Core.Domain;
using ConsultorioApp.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioApp.Data.Context
{
    public class ConsultorioAppContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public ConsultorioAppContext(DbContextOptions<ConsultorioAppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
        }
    }
}
