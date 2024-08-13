using TodoList.Client.Models;

namespace TodoList.Client.Interfaces
{
    public interface ITodoDataProvider
    {
        Task<IEnumerable<TodoModel>> GetTodosAsync(int pageSize, int skip);
        Task<int> GetTotalCountAsync();
        Task<bool> DeleteTodoByIdAsync(int id);
    }
}
