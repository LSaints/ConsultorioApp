using ConsultorioApp.Core.Domain;
using ConsultorioApp.Data.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsultorioApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteManager _manager;
        public ClienteController(IClienteManager manager)
        {
            _manager = manager;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _manager.GetClientesAsync());
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _manager.GetClienteAsync(id));
        }

        // POST api/<ClienteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
