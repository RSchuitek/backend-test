using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace PBBackend.Api.ViewModels.PessoaViewModels
{
    public class EditorPessoaViewModel : Notifiable, IValidatable  
    {
        public int Id {get; set;}
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DddTelefone { get; set; }
        public string Telefone { get; set; }
        
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Nome, "Nome", "O Nome é requerido")
                    .HasMaxLengthIfNotNullOrEmpty(Nome, 120, "Nome", "O Nome deve conter pelo até 120 caracteres")
                    .HasMinLengthIfNotNullOrEmpty(Nome, 3, "Nome", "O Nome deve conter pelo menos 3 caracteres")
                    .IsEmailOrEmpty(Email, "Email", "E-mail não é valido")
                    .IsNotNullOrEmpty(Email, "Email", "O E-mail é requerido")
                    .HasMaxLengthIfNotNullOrEmpty(Email, 100, "Email", "O E-mail deve conter pelo até 100 caracteres")
                    .HasMinLengthIfNotNullOrEmpty(Email, 10, "Email", "O E-mail deve conter pelo menos 10 caracteres")
                    .HasLen(DddTelefone, 2, "DddTelefone", "O DDD deve ser igual 2 caracteres")
                    .HasMinLen(Telefone, 7, "Telefone", "O Telefone deve conter pelo menos 7 caracteres")
                    .HasMaxLen(Telefone, 9, "Telefone", "O Telefone deve conter pelo até 9 caracteres")
            );
        }
    }
}