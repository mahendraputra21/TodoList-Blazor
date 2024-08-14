using TodoList.Server.TodoList.Interfaces;
using TodoList.Server.TodoList.Services;

namespace TodoList.Server.TodoList.Configuration
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddTodoServices(this IServiceCollection services)
        {
            services.AddTransient<ITodoDataProvider, TodoDataProvider>();
            services.AddTransient<ITodoService, TodoService>();
            services.AddTransient<ITodoSearchService, TodoSearchService>();
            return services;
        }
    }
}
