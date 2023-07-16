using ConsultorioApp.Core.Domain;
using ConsultorioApp.Shared.ModelView;

namespace ConsultorioApp.Manager.Interfaces.Managers
{
    public interface IClienteManager
    {
        Task<Cliente> DeleteClienteAsync(int id);
        Task<Cliente> GetClienteAsync(int id);
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> InsertClienteAsync(NovoCliente novoCliente);
        Task<Cliente> UpdateClienteAsync(AlteraCliente cliente);
    }
}
