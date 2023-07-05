using ConsultorioApp.Core.Domain;

namespace ConsultorioApp.Manager.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetClienteAsync(int id);
        Task<IEnumerable<Cliente>> GetClientesAsync();
    }
}
