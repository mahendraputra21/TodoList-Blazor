using TodoList.Client.Interfaces;
using TodoList.Client.Models;

namespace TodoList.Client.Services
{
    public class TodoDataProvider : ITodoDataProvider
    {
        private readonly ITodoService _todoService;

        public TodoDataProvider(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<IEnumerable<TodoModel>> GetTodosAsync(int pageSize, int skip)
        {
            var response = await _todoService.GetTodosByPaginationAsync(pageSize, skip);
            return response?.Todos ?? Enumerable.Empty<TodoModel>();
        }

        public async Task<int> GetTotalCountAsync()
        {
            var response = await _todoService.GetTodosByPaginationAsync(0, 0);
            return response?.Total ?? 0;
        }

        public async Task<bool> DeleteTodoByIdAsync(int id)
        {
           return await _todoService.DeleteTodoByIdAsync(id);
        }
    }
}
