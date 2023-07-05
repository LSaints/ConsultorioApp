using ConsultorioApp.Core.Domain;

namespace ConsultorioApp.Data.Repository
{
    public interface IClienteManager
    {
        Task<Cliente> GetClienteAsync(int id);
        Task<IEnumerable<Cliente>> GetClientesAsync();
    }
}
