using TodoList.Client;
using TodoList.Client.Interfaces;
using TodoList.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("DummyJson", client =>
{
    client.BaseAddress = new Uri("https://dummyjson.com");
});

// Blazor Bootsrtap Registration
builder.Services.AddBlazorBootstrap();

// Register Service
builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddTransient<ITodoDataProvider, TodoDataProvider>();
builder.Services.AddTransient<ITodoSearchService, TodoSearchService>();
builder.Services.AddTransient<INotificationService, NotificationService>();

//builder.Services.AddMsalAuthentication(options =>
//{
//    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
//});

await builder.Build().RunAsync();
