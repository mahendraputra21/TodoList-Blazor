using TodoList.Server.TodoList.Models;

namespace TodoList.Server.TodoList.Interfaces
{
    public class TodoDataProvider : ITodoDataProvider
    {
        private readonly ITodoService _todoService;

        public TodoDataProvider(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<TodoResponse?> GetTodosAsync(int pageSize, int skip)
        {
            return await _todoService.GetTodosByPaginationAsync(pageSize, skip);
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
