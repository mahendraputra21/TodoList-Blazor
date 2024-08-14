using TodoList.Server.Features.TodoLists.Models;

namespace TodoList.Server.Features.TodoLists.Interfaces
{
    public interface ITodoSearchService
    {
        IEnumerable<TodoDto> SearchTodos(IEnumerable<TodoDto> todos, string? searchTerm);
    }
}
