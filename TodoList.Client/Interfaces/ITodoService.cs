using TodoList.Client.Models;

namespace TodoList.Client.Interfaces
{
    public interface ITodoService
    {
        Task<TodoResponse?> GetTodosByPaginationAsync(int limit, int skip);
        Task<bool> DeleteTodoByIdAsync(int id);
    }
}
