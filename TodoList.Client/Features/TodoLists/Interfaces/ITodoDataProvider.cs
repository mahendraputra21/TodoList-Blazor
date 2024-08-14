using TodoList.Client.Features.TodoLists.Models;

namespace TodoList.Client.Features.TodoLists.Interfaces
{
    public interface ITodoDataProvider
    {
        Task<IEnumerable<TodoModel>> GetTodosAsync(int pageSize, int skip);
        Task<int> GetTotalCountAsync();
        Task<bool> DeleteTodoByIdAsync(int id);
    }
}
