using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace PBBackend.Api.ViewModels.EnderecoViewModels
{
    public class EditorEnderecoViewModel : Notifiable, IValidatable  
    {
        public int Id {get; set;}
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public int CidadeId { get; set; }
        public int PessoaId { get; set; }
        
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(Logradouro, 120, "Logradouro", "O Logradouro deve conter pelo até 120 caracteres")
                    .HasMinLen(Logradouro, 3, "Logradouro", "O Logradouro deve conter pelo menos 3 caracteres")
            );
        }
    }
}