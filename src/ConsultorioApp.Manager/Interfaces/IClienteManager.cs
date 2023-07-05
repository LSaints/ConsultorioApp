using ConsultorioApp.Core.Domain;
using ConsultorioApp.Shared.ModelView;

namespace ConsultorioApp.Data.Repository
{
    public interface IClienteManager
    {
        Task DeleteClienteAsync(int id);
        Task<Cliente> GetClienteAsync(int id);
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> InsertClienteAsync(NovoCliente novoCliente);
        Task<Cliente> UpdateClienteAsync(AlteraCliente cliente);
    }
}
