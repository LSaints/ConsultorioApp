using ConsultorioApp.Core.Domain;
using ConsultorioApp.Shared.ModelView;

namespace ConsultorioApp.Manager.Interfaces
{
    public interface IMedicoManager
    {
        Task DeleteMedicoAsync(int id);
        Task<Medico> GetMedicoAsync(int id);
        Task<IEnumerable<Medico>> GetMedicosAsync();
        Task<Medico> InsertMedicoAsync(Medico medico);
        Task<Medico> UpdateMedicoAsync(Medico medico);
    }
}
