﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BibliotecaVirtual.Core.Entidades;

public partial class Categoria
{
    public Categoria(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; set; }

    public string Nome { get; set; }

    public virtual ICollection<Livro> Livro { get; set; } = new List<Livro>();

    public void Update(string nome)
    {
        Nome = nome;
    }
}