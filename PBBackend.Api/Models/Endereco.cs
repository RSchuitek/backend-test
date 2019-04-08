using System;
using System.Collections.Generic;

namespace PBBackend.Api.Models
{
    public class Endereco : Base
    {
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}