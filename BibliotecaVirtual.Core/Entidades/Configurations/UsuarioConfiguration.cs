﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using BibliotecaVirtual.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace BibliotecaVirtual.Core.Entidades.Configurations
{
    public partial class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07372CE9BC");

            entity.Property(e => e.DataNasc).HasPrecision(0);
            entity.Property(e => e.Email)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.NomeCompleto)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.Papel)
            .HasMaxLength(20)
            .IsUnicode(false);
            entity.Property(e => e.Senha)
            .HasMaxLength(100)
            .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Usuario> entity);
    }
}