using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PBBackend.Api.Models;

namespace PBBackend.Api.Data.Maps
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.Email).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.DddTelefone).HasMaxLength(2).HasColumnType("char(2)");
            builder.Property(x => x.Telefone).HasMaxLength(9).HasColumnType("varchar(9)");
        }
    }
}