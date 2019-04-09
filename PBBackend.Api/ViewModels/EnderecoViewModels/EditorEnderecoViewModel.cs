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
                    .Requires()
                    .IsNullOrNullable(Cep, "Cep", "O Cep é requerido")
                    .IsNotNullOrEmpty(Logradouro, "Logradouro", "O Logradouro é requerido")
                    .IsNullOrNullable(Numero, "Numero", "O Numero é requerido")
                    .IsNotNullOrEmpty(Bairro, "Bairro", "O Bairro é requerido")

                    .HasMaxLengthIfNotNullOrEmpty(Logradouro, 120, "Logradouro", "O Logradouro deve conter pelo até 100 caracteres")
                    .HasMinLengthIfNotNullOrEmpty(Logradouro, 5, "Logradouro", "O Logradouro deve conter pelo menos 5 caracteres")

                    .HasMaxLen(Complemento, 50, "Complemento", "O Complemento deve conter pelo até 50 caracteres")
                    .HasMinLen(Complemento, 5, "Complemento", "O Complemento deve conter pelo menos 5 caracteres")

                    .HasMaxLengthIfNotNullOrEmpty(Bairro, 60, "Bairro", "O Bairro deve conter pelo até 60 caracteres")
                    .HasMinLengthIfNotNullOrEmpty(Bairro, 3, "Bairro", "O Bairro deve conter pelo menos 3 caracteres")

                    .HasMaxLen(Logradouro, 120, "Logradouro", "O Logradouro deve conter pelo até 120 caracteres")
                    .HasMinLen(Logradouro, 3, "Logradouro", "O Logradouro deve conter pelo menos 3 caracteres")
            );
        }
    }
}