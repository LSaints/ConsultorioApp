using ConsultorioApp.Core.Domain;
using ConsultorioApp.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioApp.Data.Context
{
    public class ConsultorioAppContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidade> Especialidades  { get; set; }

        public ConsultorioAppContext(DbContextOptions<ConsultorioAppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new TelefoneConfiguration());
            modelBuilder.ApplyConfiguration(new MedicoConfiguration());
            modelBuilder.ApplyConfiguration(new EspecialidadeConfiguration());
        }
    }
}
