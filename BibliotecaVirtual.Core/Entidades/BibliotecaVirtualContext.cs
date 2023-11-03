﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using BibliotecaVirtual.Core.Entidades.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
#nullable disable

namespace BibliotecaVirtual.Core.Entidades;

public partial class BibliotecaVirtualContext : DbContext
{
    public BibliotecaVirtualContext(DbContextOptions<BibliotecaVirtualContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Livro> Livro { get; set; }

    public virtual DbSet<LivroComentario> LivroComentario { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<UsuarioLivro> UsuarioLivro { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BibliotecaVirtualContext).Assembly);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
