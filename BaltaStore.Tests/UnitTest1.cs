using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            var c = new Customer("Eduardo", "Correia", "99999999999", "eduardocorreia@gmail.com", "81999999999", "Somewhere street, 42");

        }
    }
}
