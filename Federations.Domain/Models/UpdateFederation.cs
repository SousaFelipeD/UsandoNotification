using Flunt.Notifications;
using Flunt.Validations;

namespace Federations.Domain.Models
{
    public class UpdateFederation : Notifiable, IValidatable
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Id, nameof(Id), "O ID deve ser informado")
                .HasMinLen(Name, 3, nameof(Name), "O nome deve ter no minimo 3 caracteres")
                .HasMaxLen(Name, 50, nameof(Name), "O nome deve ter no maximo 50 caracteres")
                );
        }
    }
}
