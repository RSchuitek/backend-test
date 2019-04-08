﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PBBackend.Api.Data;

namespace PBBackend.Api.Migrations
{
    [DbContext(typeof(StoreDataContext))]
    [Migration("20190408035937_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PBBackend.Api.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataUltimaAlteracao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<int>("EstadoId");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("PBBackend.Api.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60);

                    b.Property<int>("Cep")
                        .HasColumnType("int");

                    b.Property<int>("CidadeId");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataUltimaAlteracao");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("PessoaId");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("PBBackend.Api.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataUltimaAlteracao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("PBBackend.Api.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataUltimaAlteracao");

                    b.Property<string>("DddTelefone")
                        .HasColumnType("char(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(9)")
                        .HasMaxLength(9);

                    b.HasKey("Id");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("PBBackend.Api.Models.Cidade", b =>
                {
                    b.HasOne("PBBackend.Api.Models.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PBBackend.Api.Models.Endereco", b =>
                {
                    b.HasOne("PBBackend.Api.Models.Cidade", "Cidade")
                        .WithMany("Enderecos")
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PBBackend.Api.Models.Pessoa", "Pessoa")
                        .WithMany("Enderecos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
