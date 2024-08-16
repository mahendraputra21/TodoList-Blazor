using TodoList.Server.TodoList.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Services
builder.Services.AddTodoServices();
builder.Services.AddAuthService();
builder.Services.AddFacebookAuthService(configuration);

// Read configuration
string clientUrl = configuration["ClientUrl"]!;
string thridPartyURLBase = configuration["DummyJsonBaseUrl"]!;

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

// Use CORS middleware
app.UseCors("AllowTodoClient");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
