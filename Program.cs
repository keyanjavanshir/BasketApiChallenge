var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Adds token to the request
builder.Services.AddHttpClient<TokenService>();
builder.Services.AddSingleton<TokenProvider>();

// Authentication
builder.Services.AddTransient<AuthenticatedHttpClientHandler>();
builder.Services.AddHttpClient("AuthenticatedClient")
    .AddHttpMessageHandler<AuthenticatedHttpClientHandler>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
