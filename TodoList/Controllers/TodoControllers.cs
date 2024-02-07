using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _todoContext;

        public TodoController(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }
        [EnableCors("Localhost")]
        [HttpGet]
        public async Task<IActionResult> GetAllTodo()
        {
            var todos = await _todoContext.TodoItems.ToListAsync();

            return Ok(todos);

        }

        [EnableCors("Localhost")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoItem todoItem)
        {
            _todoContext.TodoItems.Add(todoItem);
            await _todoContext.SaveChangesAsync();

            return Ok(todoItem);
        }

        [EnableCors("Localhost")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(string id)
        {
            _todoContext.TodoItems.Remove(new TodoItem { Id = id });
            await _todoContext.SaveChangesAsync();

            return Ok(id);
        }

    }
}