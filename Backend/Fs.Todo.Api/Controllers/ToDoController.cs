using Fs.Todo.Api.Models;
using Fs.Todo.Core.Interfaces;
using Fs.Todo.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fs.Todo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : Controller
    {
        private readonly ITodoService _todoService;
        public ToDoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        [HttpGet("{id}")]
        [ActionName("GetTodoAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ToDoModel>> GetTodoAsync(Guid id)
        {
            var todo = await _todoService.GetTodoAsync(id);
            if(todo is null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ToDoModel>>> GetTodosAsync()
        {
            var todos = await _todoService.GetTodosAsync();
            return Ok(todos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ToDoModel>> CreateTodoAsync(CreateTodoModel createTodoModel)
        {
            var todoModel = new ToDoModel
            {
                Description = createTodoModel.Description,
                IsCompleted = createTodoModel.IsCompleted
            };
            var createdTodo = await _todoService.CreateTodoAsync(todoModel);
            return CreatedAtAction(nameof(GetTodoAsync), new { id = createdTodo.id}, createdTodo);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<ToDoModel>> UpdateTodoAsync(Guid id, UpdatedTodoModel updateModel)
        {
            if (id != updateModel.Id)
            {
                return BadRequest();
            }
            var todo = await _todoService.GetTodoAsync(id);
            if (todo is null)
            {
                return NotFound();
            }
            var todoModel = new ToDoModel
            {
                id = id,
                Description = updateModel.Description,
                IsCompleted = updateModel.IsCompleted
            };
            var updated = await _todoService.UpdateTodoAsync(todoModel);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeletedTodoAsync(Guid id)
        {
            var todo = await _todoService.GetTodoAsync(id);
            if (todo is null)
            {
                return NotFound();
            }
            await _todoService.DeleteTodoAsync(id);
            return NoContent();
        }
    }
}
