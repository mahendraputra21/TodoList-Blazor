using TodoList.Server.TodoList.Models;

namespace TodoList.Server.TodoList.Interfaces
{
    public interface ITodoSearchService
    {
        IEnumerable<TodoDto> SearchTodos(IEnumerable<TodoDto> todos, string? searchTerm);
    }
}
