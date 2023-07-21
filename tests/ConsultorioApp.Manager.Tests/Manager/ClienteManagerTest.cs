using AutoMapper;
using ConsultorioApp.Core.Domain;
using ConsultorioApp.Data.Implementation;
using ConsultorioApp.FakeData.ClienteData;
using ConsultorioApp.Manager.Interfaces.Managers;
using ConsultorioApp.Manager.Interfaces.Repositories;
using ConsultorioApp.Manager.Mappings;
using ConsultorioApp.Shared.ModelView;
using NSubstitute;
using Xunit;
using FluentAssertions;
using NSubstitute.ReturnsExtensions;

namespace ConsultorioApp.Manager.Tests.Manager
{
    public class ClienteManagerTest
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        private readonly IClienteManager _manager;
        private readonly Cliente _cliente;
        private readonly NovoCliente _novoCliente;
        private readonly AlteraCliente _alteraCliente;
        private readonly ClienteFaker _clienteFaker;
        private readonly NovoClienteFaker _novoClienteFaker;
        private readonly AlteraClienteFaker _alteraClienteFaker;
        public ClienteManagerTest()
        {
            _repository = Substitute.For<IClienteRepository>();
            _mapper = new MapperConfiguration(p => p.AddProfile<NovoClienteMappingProfile>()).CreateMapper();
            _manager = new ClienteManager(_repository, _mapper);
            _clienteFaker = new ClienteFaker();
            _novoClienteFaker = new NovoClienteFaker();
            _alteraClienteFaker = new AlteraClienteFaker();

            _cliente = _clienteFaker.Generate();
            _novoCliente = _novoClienteFaker.Generate();
            _alteraCliente = _alteraClienteFaker.Generate();
        }

        [Fact]
        public async Task GetClientesAsync_Sucesso()
        {
            var listaClientes = _clienteFaker.Generate(10);
            _repository.GetClientesAsync().Returns(listaClientes);
            var controller = _mapper.Map<IEnumerable<Cliente>, IEnumerable<Cliente>>(listaClientes);
            var retorno = await _manager.GetClientesAsync();

            await _repository.Received().GetClientesAsync();
            retorno.Should().BeEquivalentTo(controller);
        }

        [Fact]
        public async Task GetClientesAsync_Vazio()
        {
            _repository.GetClientesAsync().Returns(new List<Cliente>());

            var retorno = await _manager.GetClientesAsync();

            await _repository.Received().GetClientesAsync();
            retorno.Should().BeEquivalentTo(new List<Cliente>());
        }

        [Fact]
        public async Task GetClienteAsync_Sucesso()
        {
            _repository.GetClienteAsync(Arg.Any<int>()).Returns(_cliente);
            var controller = _mapper.Map<Cliente>(_cliente);
            var retorno = await _manager.GetClienteAsync(_cliente.Id);

            await _repository.Received().GetClienteAsync(Arg.Any<int>());
            retorno.Should().BeEquivalentTo(controller);
        }

        [Fact]
        public async Task GetClienteAsync_NaoEncotrado()
        {
            _repository.GetClienteAsync(Arg.Any<int>()).Returns(new Cliente());
            var controller = _mapper.Map<Cliente>(new Cliente());
            var retorno = await _manager.GetClienteAsync(1);

            await _repository.Received().GetClienteAsync(Arg.Any<int>());
            retorno.Should().BeEquivalentTo(controller);
        }

        [Fact]
        public async Task InsertClienteAsync_Sucesso()
        {
            _repository.InsertClienteAsync(Arg.Any<Cliente>()).Returns(_cliente);
            var controller = _mapper.Map<Cliente>(_cliente);
            var retorno = await _manager.InsertClienteAsync(_novoCliente);

            await _repository.Received().InsertClienteAsync(Arg.Any<Cliente>());
            retorno.Should().BeEquivalentTo(controller);
        }

        [Fact]
        public async Task UpdateClienteAsync_Sucesso()
        {
            _repository.UpdateClienteAsync(Arg.Any<Cliente>()).Returns(_cliente);
            var controller = _mapper.Map<Cliente>(_cliente);
            var retorno = await _manager.UpdateClienteAsync(_alteraCliente);

            await _repository.Received().UpdateClienteAsync(Arg.Any<Cliente>());
            retorno.Should().BeEquivalentTo(controller);
        }

        [Fact]
        public async Task UpdateClienteAsync_NaoEncotrado()
        {
            _repository.UpdateClienteAsync(Arg.Any<Cliente>()).ReturnsNull();
            
            var retorno = await _manager.UpdateClienteAsync(_alteraCliente);

            await _repository.Received().UpdateClienteAsync(Arg.Any<Cliente>());
            retorno.Should().BeNull();
        }

        [Fact]
        public async Task DeleteClienteAsync_Sucesso()
        {
            _repository.DeleteClienteAsync(Arg.Any<int>()).Returns(_cliente);
            var controller = _mapper.Map<Cliente>(_cliente);
            var retorno = await _manager.DeleteClienteAsync(_cliente.Id);

            await _repository.Received().DeleteClienteAsync(Arg.Any<int>());
            retorno.Should().BeEquivalentTo(controller);
        }

        [Fact]
        public async Task DeleteClienteAsync_NaoEncotrado()
        {
            _repository.DeleteClienteAsync(Arg.Any<int>()).ReturnsNull();

            var retorno = await _manager.DeleteClienteAsync(1);

            await _repository.Received().DeleteClienteAsync(Arg.Any<int>());
            retorno.Should().BeNull();
        }
    }
}
