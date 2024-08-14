using TodoList.Server.TodoList.Models;

namespace TodoList.Server.TodoList.Interfaces
{
    public class TodoSearchService : ITodoSearchService
    {
        public IEnumerable<TodoDto> SearchTodos(IEnumerable<TodoDto> todos, string? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return todos;

            return todos.Where(todo =>
                searchTerm.Equals("true", StringComparison.OrdinalIgnoreCase) ? todo.Completed :
                searchTerm.Equals("false", StringComparison.OrdinalIgnoreCase) ? !todo.Completed :
                todo.Id.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                todo.Todo.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
            );
        }
    }
}
