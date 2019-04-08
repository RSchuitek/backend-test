using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PBBackend.Api.Models;

namespace PBBackend.Api.Data.Maps
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cep).IsRequired().HasColumnType("int");
            builder.Property(x => x.Logradouro).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.Numero).IsRequired().HasColumnType("int");
            builder.Property(x => x.Complemento).HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(60).HasColumnType("varchar(60)");
            builder.Property(x => x.DataCriacao).IsRequired();
            builder.Property(x => x.DataUltimaAlteracao).IsRequired();
            builder.HasOne(x => x.Cidade).WithMany(x => x.Enderecos);
            builder.HasOne(x => x.Pessoa).WithMany(x => x.Enderecos);
        }
    }
}