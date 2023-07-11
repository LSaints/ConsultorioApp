using ConsultorioApp.Core.Domain;
using ConsultorioApp.Data.Context;
using ConsultorioApp.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioApp.Data.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ConsultorioAppContext _context;
        public MedicoRepository(ConsultorioAppContext context)
        {
            _context = context;
        }
        public async Task DeleteMedicoAsync(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);
            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();

        }

        public async Task<Medico> GetMedicoAsync(int id)
        {
            return await _context.Medicos
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Medico>> GetMedicosAsync()
        {
            return await _context.Medicos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Medico> InsertMedicoAsync(Medico medico)
        {
            await _context.Medicos.AddAsync(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task<Medico> UpdateMedicoAsync(Medico medico)
        {
            var medicoResultado = await _context.Medicos.FindAsync(medico.Id);
            if (medicoResultado == null)
            {
                return null;
            }
            _context.Entry(medicoResultado).CurrentValues.SetValues(medico);
            await _context.SaveChangesAsync();
            return medicoResultado;
        }
    }
}
