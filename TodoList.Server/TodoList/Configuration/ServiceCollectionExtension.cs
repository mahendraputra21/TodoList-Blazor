using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.Extensions.Options;
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

        public static IServiceCollection AddAuthService(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = FacebookDefaults.AuthenticationScheme;
            })
            .AddCookie();

            return services;
        }

        public static IServiceCollection AddFacebookAuthService(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = config["Authentication:Facebook:AppId"]!;
                facebookOptions.AppSecret = config["Authentication:Facebook:AppSecret"]!;
                //facebookOptions.Scope.Add("email");
                facebookOptions.SaveTokens = true;
            });

            return services;
        }
    }
}
