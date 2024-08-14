using TodoList.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TodoList.Client.Features.TodoLists.Interfaces;
using TodoList.Client.Features.TodoLists.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("TodoListServer", client =>
{
    client.BaseAddress = new Uri("https://localhost:7054");
});

// Blazor Bootsrtap Registration
builder.Services.AddBlazorBootstrap();

// Register Service
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<ITodoDataProvider, TodoDataProvider>();
builder.Services.AddScoped<ITodoSearchService, TodoSearchService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

await builder.Build().RunAsync();
