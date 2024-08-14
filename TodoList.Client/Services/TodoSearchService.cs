using System.Net.Http.Json;
using TodoList.Client.Interfaces;
using TodoList.Client.Models;

namespace TodoList.Client.Services
{
    public class TodoSearchService : ITodoSearchService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<TodoService> _logger;

        public TodoSearchService(IHttpClientFactory clientFactory, ILogger<TodoService> logger)
        {
            _httpClient = clientFactory.CreateClient("TodoListServer");
            _logger = logger;
        }

        public async Task<List<TodoModel>?> SearchTodos(string searchTerm)
        {
            try
            {
                var encodedSearchTerm = Uri.EscapeDataString(searchTerm);
                var response = await _httpClient.GetAsync($"/api/todo/search?searchTerm={searchTerm}");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<List<TodoModel>>();
                if (result?.Count > 0) 
                {
                    return result.OrderBy(o => o.Todo).ToList();
                }
                return [];
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Error fetching data: {ex.Message}");
                return null;
            }
        }
    }
}
