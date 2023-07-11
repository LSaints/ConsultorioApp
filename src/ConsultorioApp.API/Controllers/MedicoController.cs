﻿using ConsultorioApp.Core.Domain;
using ConsultorioApp.Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : Controller
    {
        private readonly IMedicoManager _manager;
        public MedicoController(IMedicoManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Medico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get()
        {
            return Ok(await _manager.GetMedicosAsync());
        }

        // GET api/<MedicoController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _manager.GetMedicoAsync(id));
        }

        // POST api/<MedicoController>
        [HttpPost]
        [ProducesResponseType(typeof(Medico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post([FromBody] Medico medico)
        {
            var medicoInserido = await _manager.InsertMedicoAsync(medico);
            return CreatedAtAction(nameof(Get), new { id = medicoInserido.Id }, medicoInserido);
        }

        // PUT api/<MedicoController>/5
        [HttpPut]
        [ProducesResponseType(typeof(Medico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put([FromBody] Medico medico)
        {
            var medicoAtualizado = await _manager.UpdateMedicoAsync(medico);
            if (medicoAtualizado == null)
            {
                return NotFound();
            }
            return Ok(medicoAtualizado);
        }

        // DELETE api/<MedicoController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Medico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            await _manager.DeleteMedicoAsync(id);
            return NoContent();
        }
    }
}
