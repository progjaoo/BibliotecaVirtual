using BibliotecaVirtual.Application.Commands.Livro.AdicionarLivro;
using BibliotecaVirtual.Application.Commands.Livros.Atualizar;
using BibliotecaVirtual.Application.Commands.Livros.Deletar;
using BibliotecaVirtual.Core.Entidades;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using BibliotecaVirtual.Infrastructure.Repositorios;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var connection = builder.Configuration.GetConnectionString("BibliotecaDb");
builder.Services.AddDbContext<BibliotecaVirtualContext>(p => p.UseSqlServer(connection));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependency injection mediator
builder.Services.AddMediatR(typeof(AddLivroCommand));
builder.Services.AddMediatR(typeof(AtualizarLivroCommand));
builder.Services.AddMediatR(typeof(DeletarLivroCommand));

//dependency injection repositories
builder.Services.AddScoped<ILivroRepositorio, LivroRepositorio>();
builder.Services.AddScoped<IUsuarioLivroRepositorio, UsuarioLivroRepositorio>();
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();


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
