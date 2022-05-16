using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void MustValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Eduardo";
            command.LastName = "Correia";
            command.Document = "23847927094";
            command.Email = "edvin@gmail.com";
            command.Phone = "81999999999";

            Assert.AreEqual(true, command.Valid());
        }
    }
}
