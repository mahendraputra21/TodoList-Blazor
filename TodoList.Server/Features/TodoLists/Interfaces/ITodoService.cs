using TodoList.Server.Features.TodoLists.Models;

namespace TodoList.Server.Features.TodoLists.Interfaces
{
    public interface ITodoService
    {
        Task<TodoResponse?> GetTodosByPaginationAsync(int limit, int skip);
        Task<bool> DeleteTodoByIdAsync(int id);
    }
}
