using Microsoft.AspNetCore.Mvc;
using ToDo.API.DTOs;
using ToDo.API.Services.Interfaces;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoItemService _service;

        public ToDoItemController(IToDoItemService service)
        {
            _service = service;
        }

        // GET: api/ToDoItem
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        // GET: api/ToDoItem/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // POST: api/ToDoItem
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ToDoCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdItem = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
        }

        // PUT: api/ToDoItem/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ToDoUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedItem = await _service.UpdateAsync(id, dto);
            if (updatedItem == null) return NotFound();
            return Ok(updatedItem);
        }

        // DELETE: api/ToDoItem/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
