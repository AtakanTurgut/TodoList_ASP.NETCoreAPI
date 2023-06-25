using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todos.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Todos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodoContext _todoContext;

        public TodosController(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        // GET: api/<TodosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            return await _todoContext.Todos.ToListAsync();
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(int id)
        {
            var todo = await _todoContext.Todos.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }

        // POST api/<TodosController>
        [HttpPost]
        public async Task<ActionResult<Todo>> PostTodo(Todo todo)
        {
            _todoContext.Todos.Add(todo);
            await _todoContext.SaveChangesAsync();

            return CreatedAtAction("GetTodo", new { id = todo.Id }, todo);
        }

        private bool TodoExists(int id)
        {
            return _todoContext.Todos.Any(e => e.Id == id);
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Todo>>  PutTodo(int id, Todo todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }

            _todoContext.Entry(todo).State = EntityState.Modified;

            try
            {
                await _todoContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return todo;
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todo = await _todoContext.Todos.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            _todoContext.Todos.Remove(todo);
            await _todoContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
