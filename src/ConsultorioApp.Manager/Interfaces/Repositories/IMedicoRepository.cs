using ConsultorioApp.Core.Domain;

namespace ConsultorioApp.Manager.Interfaces.Repositories
{
    public interface IMedicoRepository
    {
        Task<Medico> GetMedicoAsync(int id);
        Task<IEnumerable<Medico>> GetMedicosAsync();
        Task<Medico> InsertMedicoAsync(Medico Medico);
        Task<Medico> UpdateMedicoAsync(Medico Medico);
        Task DeleteMedicoAsync(int id);

    }
}
