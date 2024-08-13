using TodoList.Client.Interfaces;
using TodoList.Client.Models;

namespace TodoList.Client.Services
{
    public class TodoSearchService : ITodoSearchService
    {
        public IEnumerable<TodoModel> SearchTodos(IEnumerable<TodoModel> todos, string searchTerm)
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
