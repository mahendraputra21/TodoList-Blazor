using TodoList.Server.TodoList.Models;

namespace TodoList.Server.TodoList.Interfaces
{
    public interface ITodoService
    {
        Task<TodoResponse?> GetTodosByPaginationAsync(int limit, int skip);
        Task<bool> DeleteTodoByIdAsync(int id);
    }
}
