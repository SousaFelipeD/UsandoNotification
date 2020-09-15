using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Federations.Domain.Entities
{
    public class Federation : Notifiable
    {
        public Federation(string name)
        {
            Id = Guid.NewGuid();
            Name = name;

            AddNotifications(new Contract()
                .HasMinLen(Name, 3, nameof(Name), "O nome deve ter no minimo 3 caracteres")
                .HasMaxLen(Name, 50, nameof(Name), "O nome deve ter no maximo 50 caracteres")
                );

        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
