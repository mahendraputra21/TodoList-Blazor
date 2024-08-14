using TodoList.Server.TodoList.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Services
builder.Services.AddTodoServices();

// Read configuration
string clientUrl = builder.Configuration["ClientUrl"]!;
string thridPartyURLBase = builder.Configuration["DummyJsonBaseUrl"]!;

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowTodoClient", policy =>
    {
        policy.WithOrigins(clientUrl)
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Register External API
builder.Services.AddHttpClient("DummyJson", (client) =>
{
    client.BaseAddress = new Uri(thridPartyURLBase);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Use CORS middleware
app.UseCors("AllowTodoClient");

app.Run();
