using AutoMapper;
using ConsultorioApp.Core.Domain;
using ConsultorioApp.Data.Repository;
using ConsultorioApp.Manager.Interfaces;
using ConsultorioApp.Shared.ModelView;

namespace ConsultorioApp.Data.Implementation
{
    public class ClienteManager : IClienteManager
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        public ClienteManager(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _repository.GetClientesAsync();
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            return await _repository.GetClienteAsync(id);
        }

        public async Task DeleteClienteAsync(int id)
        {
            await _repository.DeleteClienteAsync(id);
        }

        public async Task<Cliente> InsertClienteAsync(NovoCliente novoCliente)
        {
            var cliente = _mapper.Map<Cliente>(novoCliente);
            return await _repository.InsertClienteAsync(cliente);
        }

        public async Task<Cliente> UpdateClienteAsync(AlteraCliente alteraCliente)
        {
            var cliente = _mapper.Map<Cliente>(alteraCliente);
            return await _repository.UpdateClienteAsync(cliente);
        }
    }
}
