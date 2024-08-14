using TodoList.Client.Models;

namespace TodoList.Client.Interfaces
{
    public interface ITodoSearchService
    {
        Task<List<TodoModel>?> SearchTodos(string searchTerm);
    }
}
