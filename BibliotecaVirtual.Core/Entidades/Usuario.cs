﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BibliotecaVirtual.Core.Entidades;

public partial class Usuario
{
    public Usuario(string nomeCompleto, string email, DateTime? dataNasc, string senha)
    {
        NomeCompleto = nomeCompleto;
        Email = email;
        DataNasc = dataNasc;
        Senha = senha;
    }

    public int Id { get; set; }

    public string NomeCompleto { get; set; }

    public string Email { get; set; }

    public DateTime? DataNasc { get; set; }

    public string Senha { get; set; }

    public string Papel { get; set; } = "Usuario";

    public List<Emprestimo> Emprestimo { get; set; }


    public virtual ICollection<LivroComentario> LivroComentario { get; set; } = new List<LivroComentario>();

    public virtual ICollection<UsuarioLivro> UsuarioLivro { get; set; } = new List<UsuarioLivro>();

    public void Update(string nomeCompleto, string senha)
    {
        NomeCompleto = nomeCompleto;
        Senha = senha;
    }
}