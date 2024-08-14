using Microsoft.AspNetCore.Mvc;
using TodoList.Server.Features.TodoLists.Interfaces;
using TodoList.Server.Features.TodoLists.Models;

namespace TodoList.Server.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> log;
        private readonly ITodoDataProvider _todoDataProvider;
        private readonly ITodoSearchService _todoSearchService;

        public TodoController(
            ILogger<TodoController> log,
            ITodoDataProvider todoDataProvider,
            ITodoSearchService todoSearchService)
        {
            this.log = log;
            _todoDataProvider = todoDataProvider;
            _todoSearchService = todoSearchService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoDto>>> GetTodoByPagination(
            [FromQuery] int pageSize,
            [FromQuery] int skip)
        {
            var todos = await _todoDataProvider.GetTodosAsync(pageSize, skip);
            return Ok(todos);
        }

        [HttpGet("total-count")]
        public async Task<ActionResult<int>> GetTotalCount()
        {
            var totalCount = await _todoDataProvider.GetTotalCountAsync();
            return Ok(totalCount);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTodo(int id)
        {
            var result = await _todoDataProvider.DeleteTodoByIdAsync(id);
            if (result)
            {
                return Ok(true);
            }
            return NotFound();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<TodoDto>>> SearchTodos([FromQuery] string? searchTerm)
        {
            var allTodos = await _todoDataProvider.GetTodosAsync(int.MaxValue, 0); // Get all todos

            var todosData = allTodos?.Todos ?? Enumerable.Empty<TodoDto>();

            var searchResults = _todoSearchService.SearchTodos(todosData, searchTerm);
            return Ok(searchResults);
        }

    }
}
