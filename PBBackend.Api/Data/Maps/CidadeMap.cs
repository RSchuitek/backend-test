using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PBBackend.Api.Models;

namespace PBBackend.Api.Data.Maps
{
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("Cidade");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.Sigla).IsRequired().HasMaxLength(2).HasColumnType("varchar(2)");
            builder.Property(x => x.DataCriacao).IsRequired();
            builder.Property(x => x.DataUltimaAlteracao).IsRequired();
            builder.HasOne(x => x.Estado).WithMany(x => x.Cidades);
        }
    }
}