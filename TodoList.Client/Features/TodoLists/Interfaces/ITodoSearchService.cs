using TodoList.Client.Features.TodoLists.Models;

namespace TodoList.Client.Features.TodoLists.Interfaces
{
    public interface ITodoSearchService
    {
        Task<List<TodoModel>?> SearchTodos(string searchTerm);
    }
}
