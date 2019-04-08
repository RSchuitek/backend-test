using Microsoft.EntityFrameworkCore;
using PBBackend.Api.Data.Maps;
using PBBackend.Api.Models;

namespace PBBackend.Api.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=pb_backend;User Id=SA;Password=Admin123");
        }

         protected override void OnModelCreating(ModelBuilder builder)
         {
             builder.ApplyConfiguration(new EstadoMap());
             builder.ApplyConfiguration(new CidadeMap());
             builder.ApplyConfiguration(new EnderecoMap());
             builder.ApplyConfiguration(new PessoaMap());
         }
     }
}