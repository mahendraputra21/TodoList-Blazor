using System.Net.Http.Json;
using TodoList.Client.Features.TodoLists.Models;
using TodoList.Client.Features.TodoLists.Interfaces;

namespace TodoList.Client.Features.TodoLists.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<TodoService> _logger;

        public TodoService(IHttpClientFactory clientFactory, ILogger<TodoService> logger)
        {
            _httpClient = clientFactory.CreateClient("TodoListServer");
            _logger = logger;
        }

        public async Task<bool> DeleteTodoByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/todo/{id}");
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
                var response = await _httpClient.GetAsync($"/api/todo?limit={limit}&skip={skip}");
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
