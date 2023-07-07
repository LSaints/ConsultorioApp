using ConsultorioApp.Core.Domain;
using ConsultorioApp.Data.Repository;
using ConsultorioApp.Shared.ModelView;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsultorioApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteManager _manager;
        private readonly ILogger<ClienteController> _logger;
        public ClienteController(IClienteManager manager, ILogger<ClienteController> logger)
        {
            _manager = manager;
            _logger = logger;
            _logger.LogInformation("Controller de cliente foi chamado");
        }

        // GET: api/<ClienteController>
        [HttpGet]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("foi chamado o metodo GET de ClienteController");
            return Ok(await _manager.GetClientesAsync());
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get(int id)
        {
            _logger.LogInformation("foi chamado o metodo GET de ClienteController");
            return Ok(await _manager.GetClienteAsync(id));
        }

        // POST api/<ClienteController>
        [HttpPost]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post([FromBody] NovoCliente cliente)
        {
            _logger.LogInformation("foi chamado o metodo POST de ClienteController");
            var clienteInserido = await _manager.InsertClienteAsync(cliente);
            return CreatedAtAction(nameof(Get), new {id = clienteInserido.Id }, clienteInserido);
        }

        // PUT api/<ClienteController>/5
        [HttpPut]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put([FromBody] AlteraCliente cliente)
        {
            _logger.LogInformation("foi chamado o metodo PUT de ClienteController");
            var clienteAtualizado = await _manager.UpdateClienteAsync(cliente);
            if (clienteAtualizado == null)
            {
                return NotFound();
            }
            return Ok(clienteAtualizado);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation("foi chamado o metodo DELETE de ClienteController");
            await _manager.DeleteClienteAsync(id);
            return NoContent();
        }
    }
}
