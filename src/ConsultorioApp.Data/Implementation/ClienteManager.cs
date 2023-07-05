using ConsultorioApp.Core.Domain;
using ConsultorioApp.Data.Repository;
using ConsultorioApp.Manager.Interfaces;

namespace ConsultorioApp.Data.Implementation
{
    public class ClienteManager : IClienteManager
    {
        private readonly IClienteRepository _repository;
        public ClienteManager(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _repository.GetClientesAsync();
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            return await _repository.GetClienteAsync(id);
        }
    }
}
