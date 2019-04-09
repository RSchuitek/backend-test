using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace PBBackend.Api.ViewModels.EstadoViewModels
{
    public class EditorEstadoViewModel : Notifiable, IValidatable  
    {
        public int Id {get; set;}
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Descricao, "Descricao", "O Descrição é requerido")
                    .IsNotNullOrEmpty(Sigla, "Sigla", "O Sigla é requerido")
                    .HasMaxLen(Descricao, 120, "Descricao", "A Descrição deve conter pelo até 120 caracteres")
                    .HasMinLen(Descricao, 5, "Descricao", "A Descrição deve conter pelo menos 5 caracteres")
                    .HasLen(Sigla, 2, "Sigla", "A Sigla deve conter pelo menos 2 caracteres")
            );
        }
    }
}