using ConsultorioApp.Core.Domain;
using ConsultorioApp.Data.Context;
using ConsultorioApp.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioApp.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ConsultorioAppContext _context;
        public ClienteRepository(ConsultorioAppContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

    }
}
