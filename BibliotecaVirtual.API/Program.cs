using System.Text;
using BibliotecaVirtual.Application.Commands.Categorias.Adicionar;
using BibliotecaVirtual.Application.Commands.Categorias.Atualizar;
using BibliotecaVirtual.Application.Commands.Categorias.Deletar;
using BibliotecaVirtual.Application.Commands.Emprestimo.AdicionarEmprestimo;
using BibliotecaVirtual.Application.Commands.Livro.AdicionarLivro;
using BibliotecaVirtual.Application.Commands.LivroComentario.AddComentario;
using BibliotecaVirtual.Application.Commands.LivroComentario.AtualizarComentario;
using BibliotecaVirtual.Application.Commands.LivroComentario.DeletarComentario;
using BibliotecaVirtual.Application.Commands.Livros.Atualizar;
using BibliotecaVirtual.Application.Commands.Livros.Deletar;
using BibliotecaVirtual.Application.Commands.Usuarios.AddUsuario;
using BibliotecaVirtual.Application.Commands.Usuarios.AtualizarUsuario;
using BibliotecaVirtual.Application.Commands.Usuarios.LoginUsuario;
using BibliotecaVirtual.Core.Entidades;
using BibliotecaVirtual.Core.InterfaceService;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using BibliotecaVirtual.Infrastructure.Autenticação;
using BibliotecaVirtual.Infrastructure.Repositorios;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//connectionString com BD
var connection = builder.Configuration.GetConnectionString("BibliotecaDb");
builder.Services.AddDbContext<BibliotecaVirtualContext>(p => p.UseSqlServer(connection));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region TOKEN-JWT-BEARER
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BibliotecaVirtual.API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header usando o esquema Bearer."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
#endregion

#region INJEÇAO DE DEPENDENCIAS
//dependency injection mediator
builder.Services.AddMediatR(typeof(AddLivroCommand));
builder.Services.AddMediatR(typeof(AtualizarLivroCommand));
builder.Services.AddMediatR(typeof(DeletarLivroCommand));

builder.Services.AddMediatR(typeof(AddCategoriaCommand));
builder.Services.AddMediatR(typeof(AtualizarCategoriaCommand));
builder.Services.AddMediatR(typeof(DeletarCategoriaCommand));

builder.Services.AddMediatR(typeof(CriarUsuarioCommand));
builder.Services.AddMediatR(typeof(LoginUsuarioCommand));
builder.Services.AddMediatR(typeof(AtualizarUsuarioCommand));

builder.Services.AddMediatR(typeof(AdicionarComentarioCommand));
builder.Services.AddMediatR(typeof(AtualizarComentarioCommand));
builder.Services.AddMediatR(typeof(DeletarComentarioCommand));

builder.Services.AddMediatR(typeof(AddEmprestimoCommand));




//dependency injection repositories
builder.Services.AddScoped<ILivroRepositorio, LivroRepositorio>();
builder.Services.AddScoped<IUsuarioLivroRepositorio, UsuarioLivroRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<ILivroComentarioRepositorio, LivroComentarioRepositorio>();
builder.Services.AddScoped<IEmprestimoRepositorio, EmprestimoRepositorio>();

//AUTENTICACAO SERVICE
builder.Services.AddScoped<IServicoAutenticacao, AutenticacaoService>();

#endregion


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
