using ConsultorioApp.API.Controllers;
using ConsultorioApp.Core.Domain;
using ConsultorioApp.FakeData.ClienteData;
using ConsultorioApp.Manager.Interfaces.Managers;
using ConsultorioApp.Shared.ModelView;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace ConsultorioApp.API.Tests.Controllers
{
    public class ClienteControllerTest
    {
        private readonly IClienteManager _manager;
        private readonly ILogger<ClienteController> _logger;
        private readonly ClienteController _controller;

        private readonly Cliente _cliente;
        private readonly List<Cliente> _clientes;
        private readonly NovoCliente _novoCliente;
        public ClienteControllerTest()
        {
            _manager = Substitute.For<IClienteManager>();
            _logger = Substitute.For<ILogger<ClienteController>>();
            _controller = new ClienteController(_manager, _logger);

            _cliente = new ClienteFaker().Generate();
            _clientes = new ClienteFaker().Generate(50);
            _novoCliente = new NovoClienteFaker().Generate();
        }

        [Fact]
        public async Task Get_Ok()
        {
            var controle = new List<Cliente>();
            _clientes.ForEach(p => controle.Add(p));
            _manager.GetClientesAsync().Returns(_clientes);

            var resultado = (ObjectResult) await _controller.Get();

            await _manager.Received().GetClientesAsync();
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
            resultado.Value.Should().BeEquivalentTo(_clientes);
        }

        [Fact]
        public async Task Get_NotFound()
        {
            _manager.GetClientesAsync().Returns(new List<Cliente>());

            var resultado = (StatusCodeResult)await _controller.Get();

            await _manager.Received().GetClientesAsync();
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task GetById_Ok()
        {
            _manager.GetClienteAsync(Arg.Any<int>()).Returns(_cliente.CloneTipado());

            var resultado = (ObjectResult)await _controller.Get(_cliente.Id);

            await _manager.Received().GetClienteAsync(Arg.Any<int>());
            resultado.Value.Should().BeEquivalentTo(_cliente);
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetById_NotFound()
        {
            _manager.GetClienteAsync(Arg.Any<int>()).Returns(new Cliente());

            var resultado = (StatusCodeResult)await _controller.Get(1);

            await _manager.Received().GetClienteAsync(Arg.Any<int>());
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Post_Created()
        {
            _manager.InsertClienteAsync(Arg.Any<NovoCliente>()).Returns(_cliente.CloneTipado());

            var resultado = (ObjectResult)await _controller.Post(_novoCliente);

            await _manager.Received().InsertClienteAsync(Arg.Any<NovoCliente>());
            resultado.StatusCode.Should().Be(StatusCodes.Status201Created);
            resultado.Value.Should().BeEquivalentTo(_cliente);
        }

        [Fact]
        public async Task Put_Ok()
        {
            _manager.UpdateClienteAsync(Arg.Any<AlteraCliente>()).Returns(_cliente.CloneTipado());

            var resultado = (ObjectResult)await _controller.Put(new AlteraCliente());

            await _manager.Received().UpdateClienteAsync(Arg.Any<AlteraCliente>());
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
            resultado.Value.Should().BeEquivalentTo(_cliente);
        }

        [Fact]
        public async Task Put_NotFound()
        {
            _manager.UpdateClienteAsync(Arg.Any<AlteraCliente>()).ReturnsNull();

            var resultado = (StatusCodeResult)await _controller.Put(new AlteraCliente());

            await _manager.Received().UpdateClienteAsync(Arg.Any<AlteraCliente>());
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Delete_NoContent()
        {
            _manager.DeleteClienteAsync(Arg.Any<int>()).Returns(_cliente);

            var resultado = (StatusCodeResult)await _controller.Delete(1);

            await _manager.Received().DeleteClienteAsync(Arg.Any<int>());
            resultado.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task NotFound_NotFound()
        {
            _manager.DeleteClienteAsync(Arg.Any<int>());

            var resultado = (StatusCodeResult) await _controller.Delete(1);

            await _manager.Received().DeleteClienteAsync(Arg.Any<int>());
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}
