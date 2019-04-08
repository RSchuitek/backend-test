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
                    .HasMaxLen(Nome, 120, "Nome", "O Nome deve conter pelo até 120 caracteres")
                    .HasMinLen(Nome, 3, "Nome", "O Nome deve conter pelo menos 3 caracteres")
            );
        }
    }
}