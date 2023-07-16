using ConsultorioApp.Data.Context;
using ConsultorioApp.Manager.Interfaces.Repositories;

namespace ConsultorioApp.Data.Repository
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly ConsultorioAppContext _context;
        public EspecialidadeRepository(ConsultorioAppContext context)
        {
            _context = context;
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _context.Especialidades.FindAsync(id) != null;
        }
    }
}
