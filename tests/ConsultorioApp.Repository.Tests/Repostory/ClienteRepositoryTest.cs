using ConsultorioApp.Core.Domain;
using ConsultorioApp.Data.Context;
using ConsultorioApp.Data.Repository;
using ConsultorioApp.FakeData.ClienteData;
using ConsultorioApp.FakeData.TelefoneData;
using ConsultorioApp.Manager.Interfaces.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ConsultorioApp.Repository.Tests.Repostory
{
    public class ClienteRepositoryTest : IDisposable
    {
        private readonly IClienteRepository _repository;
        private readonly ConsultorioAppContext _context;
        private readonly Cliente _cliente;
        private readonly ClienteFaker _clienteFaker; 
        public ClienteRepositoryTest() 
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConsultorioAppContext>();
            optionsBuilder.UseInMemoryDatabase("Db_Teste");
            optionsBuilder.EnableSensitiveDataLogging();

            _context = new ConsultorioAppContext(optionsBuilder.Options);
            _repository = new ClienteRepository(_context);

            _clienteFaker = new ClienteFaker();
            _cliente = _clienteFaker.Generate();
        }

        private async Task<List<Cliente>> InserirRegistros()
        {
            var clientes = _clienteFaker.Generate(100);
            foreach (var cliente in clientes)
            {
                cliente.Id = 0;
                await _context.Clientes.AddAsync(cliente);
            }
            await _context.SaveChangesAsync();
            return clientes;
        }

        [Fact]
        public async Task GetClientesAsync_ComRetorno()
        {
            var registros = await InserirRegistros();
            var retorno = await _repository.GetClientesAsync();

            retorno.Should().HaveCount(registros.Count);
            retorno.First().Endereco.Should().NotBeNull();
            retorno.First().Telefones.Should().NotBeNull();
        }

        [Fact]
        public async Task GetClientesAsync_Vazio()
        {
            var retorno = await _repository.GetClientesAsync();
            retorno.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetClienteAsync_Encontrado()
        {
            var registros = await InserirRegistros();
            var retorno = await _repository.GetClienteAsync(registros.First().Id);

            retorno.Should().BeEquivalentTo(registros.First());
        }

        [Fact]
        public async Task GetClienteAsync_NaoEncontrado()
        {
            var retorno = await _repository.GetClienteAsync(1);
            retorno.Should().BeNull();
        }

        [Fact]
        public async Task InsertClienteAsync_Sucesso()
        {
            var retorno = await _repository.InsertClienteAsync(_cliente);
            retorno.Should().BeEquivalentTo(_cliente);
        }

        [Fact]
        public async Task UpdateClienteAsync_Sucesso()
        {
            var registros = await InserirRegistros();
            var clienteAlterado = registros.First();
            var retorno = await _repository.UpdateClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task UpdateClienteAsync_AdicionarTelefone()
        {
            var registros = await InserirRegistros();
            var clienteAlterado = registros.First();
            clienteAlterado.Telefones.Add(new TelefoneFaker(clienteAlterado.Id).Generate());
            var retorno = await _repository.UpdateClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task UpdateClienteAsync_RemoverTelefone()
        {
            var registros = await InserirRegistros();
            var clienteAlterado = registros.First();
            clienteAlterado.Telefones.Remove(clienteAlterado.Telefones.First());
            var retorno = await _repository.UpdateClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task UpdateClienteAsync_RemoverTodosTelefone()
        {
            var registros = await InserirRegistros();
            var clienteAlterado = registros.First();
            clienteAlterado.Telefones.Clear();
            var retorno = await _repository.UpdateClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task UpdateClienteAsync_NaoEncontrado()
        {
            var retorno = await _repository.UpdateClienteAsync(_cliente);
            retorno.Should().BeNull();
        }

        [Fact]
        public async Task DeleteClienteAsync_Sucesso()
        {
            var registros = await InserirRegistros();
            var removedCliente = registros.First();
            var retorno = await _repository.DeleteClienteAsync(removedCliente.Id);
            retorno.Should().BeEquivalentTo(removedCliente);
        }

        [Fact]
        public async Task DeleteClienteAsync_NaoEncontrado()
        {
            var retorno = await _repository.DeleteClienteAsync(_cliente.Id);
            retorno.Should().BeNull();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
