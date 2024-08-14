using TodoList.Server.Features.TodoLists.Interfaces;
using TodoList.Server.Features.TodoLists.Models;

namespace TodoList.Server.Features.TodoLists.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<TodoService> _logger;

        public TodoService(IHttpClientFactory clientFactory, ILogger<TodoService> logger)
        {
            _httpClient = clientFactory.CreateClient("DummyJson");
            _logger = logger;
        }

        public async Task<bool> DeleteTodoByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/todos/{id}");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Deleting data: {ex.Message}");
                return false;
            }
        }

        public async Task<TodoResponse?> GetTodosByPaginationAsync(int limit, int skip)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/todos?limit={limit}&skip={skip}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<TodoResponse?>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching data: {ex.Message}");
                return null;
            }
        }
    }
}
