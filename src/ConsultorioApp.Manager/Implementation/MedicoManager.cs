using ConsultorioApp.Core.Domain;
using ConsultorioApp.Manager.Interfaces;
using ConsultorioApp.Shared.ModelView;

namespace ConsultorioApp.Manager.Implementation
{
    public class MedicoManager : IMedicoManager
    {
        private readonly IMedicoRepository _repository;
        public MedicoManager(IMedicoRepository repository)
        {
            _repository = repository;
        }
        public async Task DeleteMedicoAsync(int id)
        {
            _repository.DeleteMedicoAsync(id);
        }

        public Task<Medico> GetMedicoAsync(int id)
        {
            return _repository.GetMedicoAsync(id);
        }

        public async Task<IEnumerable<Medico>> GetMedicosAsync()
        {
            return await _repository.GetMedicosAsync();
        }

        public async Task<Medico> InsertMedicoAsync(Medico medico)
        {
            return await _repository.InsertMedicoAsync(medico);
        }

        public async Task<Medico> UpdateMedicoAsync(Medico medico)
        {
            return await _repository.UpdateMedicoAsync(medico);
        }
    }
}
