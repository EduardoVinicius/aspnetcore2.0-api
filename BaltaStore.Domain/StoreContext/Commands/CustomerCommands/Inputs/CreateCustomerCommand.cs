using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "Name must have at least 3 characters")
                .HasMaxLen(FirstName, 40, "FirstName", "Name must have at most 40 characters")
                .HasMinLen(LastName, 3, "LastName", "Name must have at least 3 characters")
                .HasMaxLen(LastName, 40, "LastName", "Name must have at most 40 characters")
                .IsEmail(Email, "Email", "Invalid email")
                .HasLen(Document, 11, "Document", "Invalid CPF")
            );

            return IsValid;
        }
    }
}
