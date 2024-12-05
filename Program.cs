using InyeccionDependencias.DataContext;
using InyeccionDependencias.EjemploConDY;
using InyeccionDependencias.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<UsuarioServiceConDY>();  //se agrega esto para la Inyec de Dep
builder.Services.AddTransient<IEmailServiceConDY, EmailServiceConDY>();

builder.Services.AddDbContext<DataContextNorthwind>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Northwind")));

builder.Services.AddTransient<INorthwindRepository, NorthwindRepository>();


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
