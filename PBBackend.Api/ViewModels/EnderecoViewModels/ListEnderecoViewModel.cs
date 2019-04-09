using System;

namespace PBBackend.Api.ViewModels.EnderecoViewModels
{
    public class ListEnderecoViewModel 
    {
        public int Id {get; set;}
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public int CidadeId { get; set; }
        public int PessoaId { get; set; }
    }
}