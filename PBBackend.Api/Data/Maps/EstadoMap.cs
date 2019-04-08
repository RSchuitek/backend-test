using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PBBackend.Api.Models;

namespace PBBackend.Api.Data.Maps
{
    public class EstadoMap : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("Estado");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.Sigla).IsRequired().HasMaxLength(2).HasColumnType("varchar(2)");
            builder.Property(x => x.DataCriacao).IsRequired();
            builder.Property(x => x.DataUltimaAlteracao).IsRequired();
        }
    }
}