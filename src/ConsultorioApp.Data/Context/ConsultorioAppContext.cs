using ConsultorioApp.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioApp.Data.Context
{
    public class ConsultorioAppContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public ConsultorioAppContext(DbContextOptions<ConsultorioAppContext> options) : base(options)
        {
            
        }
    }
}
