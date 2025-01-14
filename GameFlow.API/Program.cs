using DotNetEnv;
using GameFlow.API.Extensions;
using GameFlow.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Carregar variáveis de ambiente do arquivo .env
Env.Load();

// Configuração do servidor HTTPS
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(7056, listenOptions =>
    {
        listenOptions.UseHttps();
    });
});

// Obtendo a string de conexão a partir de uma variável de ambiente
var connectionString = Environment.GetEnvironmentVariable("DefaultConnection")
                       ?? builder.Configuration.GetConnectionString("DefaultConnection");

// Verifique se a string de conexão foi inicializada corretamente
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("The ConnectionString property has not been initialized.");
}

// Configurando o DbContext com a string de conexão
builder.Services.AddDbContext<GameFlowDbContext>(options =>
    options.UseSqlServer(connectionString));

// Adicionando serviços customizados
builder.Services.AddCustomServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurando middlewares e pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
