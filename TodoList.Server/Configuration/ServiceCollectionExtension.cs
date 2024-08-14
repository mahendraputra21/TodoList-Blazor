using TodoList.Server.Features.TodoLists.Interfaces;
using TodoList.Server.Features.TodoLists.Services;

namespace TodoList.Server.Configuration
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddTodoServices(this IServiceCollection services)
        {
            services.AddScoped<ITodoDataProvider, TodoDataProvider>();
            services.AddTransient<ITodoService, TodoService>();
            services.AddScoped<ITodoSearchService, TodoSearchService>();
            return services;
        }
    }
}
