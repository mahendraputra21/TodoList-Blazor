using TodoList.Client;
using TodoList.Client.Interfaces;
using TodoList.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

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
builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddTransient<ITodoDataProvider, TodoDataProvider>();
builder.Services.AddTransient<ITodoSearchService, TodoSearchService>();
builder.Services.AddTransient<INotificationService, NotificationService>();

await builder.Build().RunAsync();
