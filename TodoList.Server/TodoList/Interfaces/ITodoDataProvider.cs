using TodoList.Server.TodoList.Models;

namespace TodoList.Server.TodoList.Interfaces
{
    public interface ITodoDataProvider
    {
        Task<TodoResponse?> GetTodosAsync(int pageSize, int skip);
        Task<int> GetTotalCountAsync();
        Task<bool> DeleteTodoByIdAsync(int id);
    }
}
