using System;
using System.Collections.Generic;

namespace PBBackend.Api.Models
{
    public class Pessoa : Base
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DddTelefone { get; set; }        
        public string Telefone { get; set; }        
        public IEnumerable<Endereco> Enderecos { get; set; }
    }
}