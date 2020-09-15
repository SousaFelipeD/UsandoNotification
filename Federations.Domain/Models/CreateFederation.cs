using Flunt.Notifications;
using Flunt.Validations;

namespace Federations.Domain.Models
{
    public class CreateFederation : Notifiable, IValidatable
    {
        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .HasMinLen(Name, 3, nameof(Name), "O nome deve ter no minimo 3 caracteres")
                .HasMaxLen(Name, 50, nameof(Name), "O nome deve ter no maximo 50 caracteres")
                );
        }
    }
}
