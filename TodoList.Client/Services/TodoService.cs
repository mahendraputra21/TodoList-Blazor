using TodoList.Client.Interfaces;
using TodoList.Client.Models;
using System.Net.Http.Json;

namespace TodoList.Client.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _httpClient;

        public TodoService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("DummyJson");
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
                Console.WriteLine($"Error Deleting data: {ex.Message}");
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
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return null;
            }
        }
    }
}
