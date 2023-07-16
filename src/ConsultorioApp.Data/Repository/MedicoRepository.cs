using ConsultorioApp.Core.Domain;
using ConsultorioApp.Data.Configuration;
using ConsultorioApp.Data.Context;
using ConsultorioApp.Manager.Interfaces.Repositories;
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
                .Include(p => p.Especialidades)
                .AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Medico>> GetMedicosAsync()
        {
            return await _context.Medicos
                .Include (p => p.Especialidades)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Medico> InsertMedicoAsync(Medico medico)
        {
            await InsertEspecialidadeMedico(medico);
            await _context.Medicos.AddAsync(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        private async Task InsertEspecialidadeMedico(Medico medico)
        {
            var especialidadesConsultadas = new List<Especialidade>();
            foreach (var Especialidade in medico.Especialidades)
            {
                var especialidadeConsultada = await _context.Especialidades.FindAsync(Especialidade.Id);
                especialidadesConsultadas.Add(especialidadeConsultada);
            }
            medico.Especialidades = especialidadesConsultadas;
        }

        public async Task<Medico> UpdateMedicoAsync(Medico medico)
        {
            var medicoResultado = await _context.Medicos
                .Include(p => p.Especialidades)
                .SingleOrDefaultAsync(p => p.Id == medico.Id);
            if (medicoResultado == null)
            {
                return null;
            }
            _context.Entry(medicoResultado).CurrentValues.SetValues(medico);
            await UpdateMedicoEspecialidade(medico, medicoResultado);
            await _context.SaveChangesAsync();
            return medicoResultado;
        }

        private async Task UpdateMedicoEspecialidade(Medico medico, Medico? medicoResultado)
        {
            medicoResultado.Especialidades.Clear();
            foreach (var especialidade in medico.Especialidades)
            {
                var especialidadeConsultado = await _context.Especialidades.FindAsync(especialidade.Id);
                medicoResultado.Especialidades.Add(especialidadeConsultado);
            }
        }
    }
}
