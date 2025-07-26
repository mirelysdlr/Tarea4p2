using Microsoft.AspNetCore.Mvc;
using organizadordeventos.Domain.Contracts;
using organizadordeventos.Domain.DTOs;
using organizadordeventos.Infrastructure.Exceptions;

namespace organizadordeventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        
        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoReadDto>>> GetAll()
        {
            try
            {
                var result = await _eventoService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<EventoReadDto>> GetById(int id)
        {
            try
            {
                var result = await _eventoService.GetByIdAsync(id);
                if (result == null)
                    return NotFound($"Evento con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (EventoNotFoundException)
            {
                return NotFound($"Evento con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<EventoReadDto>> Create([FromBody] EventoCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _eventoService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (EventoValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<EventoReadDto>> Update(int id, [FromBody] EventoUpdateDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _eventoService.UpdateAsync(id, updateDto);
                if (result == null)
                    return NotFound($"Evento con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (EventoNotFoundException)
            {
                return NotFound($"Evento con ID {id} no encontrado");
            }
            catch (EventoValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _eventoService.DeleteAsync(id);
                if (!result)
                    return NotFound($"Evento con ID {id} no encontrado");
                    
                return NoContent();
            }
            catch (EventoNotFoundException)
            {
                return NotFound($"Evento con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}