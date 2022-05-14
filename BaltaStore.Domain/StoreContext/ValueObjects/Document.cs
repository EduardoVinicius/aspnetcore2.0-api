using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Document : Notifiable
    {
        public Document(string number)
        {
            Number = number;

            AddNotifications(new ValidationContract()
                .IsTrue(Validate(Number), "Document", "Invalid CPF")
            );
        }

        public string Number { get; private set; }

        public bool Validate(string cpf)
        {
            return true;
        }

        public override string ToString()
        {
            return Number;
        }
    }
}
