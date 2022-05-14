using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "Name must have at least 3 characters")
                .HasMaxLen(FirstName, 40, "FirstName", "Name must have at most 40 characters")
                .HasMinLen(LastName, 3, "LastName", "Name must have at least 3 characters")
                .HasMaxLen(LastName, 40, "LastName", "Name must have at most 40 characters"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
