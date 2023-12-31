﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BibliotecaVirtual.Core.Entidades;

public partial class LivroComentario
{

    public LivroComentario(int idUsuario, int idLivro, string conteudo)
    {
        IdUsuario = idUsuario;
        IdLivro = idLivro;
        Conteudo = conteudo;
        CriadoEm = DateTime.Now;
    }

    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public int IdLivro { get; set; }

    public string Conteudo { get; set; }

    public DateTime? CriadoEm { get; set; }

    public virtual Livro IdLivroNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; }

    public void Update(string conteudo)
    {
        Conteudo = conteudo;
    }
}