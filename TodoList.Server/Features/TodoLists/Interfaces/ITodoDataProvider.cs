using TodoList.Server.Features.TodoLists.Models;

namespace TodoList.Server.Features.TodoLists.Interfaces
{
    public interface ITodoDataProvider
    {
        Task<TodoResponse?> GetTodosAsync(int pageSize, int skip);
        Task<int> GetTotalCountAsync();
        Task<bool> DeleteTodoByIdAsync(int id);
    }
}
