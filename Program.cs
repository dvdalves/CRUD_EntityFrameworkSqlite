using CrudAPI_Sqlite.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do banco de dados SQLite
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona os servi�os necess�rios
builder.Services.AddControllers();

// Adiciona a configura��o do Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Habilita o middleware do Swagger no pipeline de solicita��o HTTP
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
