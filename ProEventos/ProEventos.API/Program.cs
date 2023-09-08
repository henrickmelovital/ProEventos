using ProEventos.Application.Contratos;
using ProEventos.Application;
using ProEventos.Persistence;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Ignorar o ciclo de eventos:
builder.Services.AddControllers().AddNewtonsoftJson(
    X => X.SerializerSettings.ReferenceLoopHandling =
        Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

// Adicionando o CORS
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new InvalidOperationException("No connection string");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Injeção de Dependência:
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IGeralPersist, GeralPersist>();
builder.Services.AddScoped<IEventoPersist, EventoPersist>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Permitindo os acessos ao CORS:
app.UseCors(cors => cors
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
);

app.MapControllers();

app.Run();
