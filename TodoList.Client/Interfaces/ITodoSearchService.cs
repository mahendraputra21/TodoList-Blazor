using TodoList.Client.Models;

namespace TodoList.Client.Interfaces
{
    public interface ITodoSearchService
    {
        IEnumerable<TodoModel> SearchTodos(IEnumerable<TodoModel> todos, string searchTerm);
    }
}
