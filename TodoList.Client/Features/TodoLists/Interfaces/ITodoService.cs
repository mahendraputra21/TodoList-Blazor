using TodoList.Client.Features.TodoLists.Models;

namespace TodoList.Client.Features.TodoLists.Interfaces
{
    public interface ITodoService
    {
        Task<TodoResponse?> GetTodosByPaginationAsync(int limit, int skip);
        Task<bool> DeleteTodoByIdAsync(int id);
    }
}
