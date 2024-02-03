


using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoItem todoItem)
        {
            _todoContext.TodoItems.Add(todoItem);
            await _todoContext.SaveChangesAsync();

            return Ok(todoItem);
        }

    }
}