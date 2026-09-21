<<<<<<< HEAD

using ClientesApp.Application.Interfaces;
using ClientesApp.Application.Services;
using ClientesApp.Domain.Interfaces;
using ClientesApp.Domain.Services;
using ClientesApp.Infra.Data.Repositories;

=======
>>>>>>> cf71fa97ecae1826c6e0ae7688dafaa9714af1de
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//Configurando o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< HEAD
// Leitura das configurações do MongoDB
var connectionString = builder.Configuration["MongoDB:ConnectionString"]!;
var databaseName = builder.Configuration["MongoDB:DatabaseName"]!;

// Registrando as dependências
builder.Services.AddScoped<IClienteAppService, ClienteAppService>();
builder.Services.AddScoped<IClienteDomainService, ClienteDomainService>();
builder.Services.AddScoped<IClienteRepository>(_ =>
    new ClienteRepository(connectionString, databaseName));


// Liberando qualquer origem, método e cabeçalho
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});





var app = builder.Build();
app.UseCors("CorsAll");
=======
var app = builder.Build();
>>>>>>> cf71fa97ecae1826c6e0ae7688dafaa9714af1de

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
<<<<<<< HEAD

=======
>>>>>>> cf71fa97ecae1826c6e0ae7688dafaa9714af1de
}

//Executando o Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
