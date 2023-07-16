using ConsultorioApp.Core.Domain;

namespace ConsultorioApp.Manager.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task DeleteClienteAsync(int id);
        Task<Cliente> GetClienteAsync(int id);
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> InsertClienteAsync(Cliente cliente);
        Task<Cliente> UpdateClienteAsync(Cliente cliente);
    }
}
