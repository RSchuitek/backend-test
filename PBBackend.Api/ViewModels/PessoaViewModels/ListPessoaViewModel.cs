using System;

namespace PBBackend.Api.ViewModels.PessoaViewModels
{
    public class ListPessoaViewModel 
    {
        public int Id {get; set;}
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DddTelefone { get; set; }
        public string Telefone { get; set; }
    }
}