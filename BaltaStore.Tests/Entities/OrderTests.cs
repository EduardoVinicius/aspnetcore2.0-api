using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _screen;
        private Customer _customer;
        private Order _order;

        public OrderTests()
        {
            var name = new Name("Eduardo", "Correia");
            var document = new Document("90162212046");
            var email = new Email("edvin@gmail.com");
            _customer = new Customer(name, document, email, "81999999999");
            _order = new Order(_customer);
            _mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            _keyboard = new Product("Teclado Gamer", "Teclado Gamer", "teclado.jpg", 100M, 10);
            _chair = new Product("Cadeira Gamer", "Cadeira Gamer", "cadeira.jpg", 100M, 10);
            _screen = new Product("Monitor Gamer", "Monitor Gamer", "monitor.jpg", 100M, 10);
        }

        [TestMethod]
        public void MustCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        [TestMethod]
        public void MustCreateStatusWhenOrderIsCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        [TestMethod]
        public void MustReturn2When2ValidItemAreAdded()
        {
            _order.AddItem(_screen, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        [TestMethod]
        public void MustReturn5When5ItemsArePurchased()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        [TestMethod]
        public void MustReturnANumberWhenOrderIsPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        [TestMethod]
        public void MustReturnPaidWhenOrderIsPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        [TestMethod]
        public void MustReturn2When10ProductsArePurchased()
        {
            _order.AddItem(_screen, 5);
            _order.AddItem(_screen, 5);
            _order.AddItem(_screen, 5);
            _order.AddItem(_screen, 5);
            _order.AddItem(_screen, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        [TestMethod]
        public void StatusMustBeCanceledWhenOrderIsCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        [TestMethod]
        public void DeliveriesMustBeCanceledWhenOrderIsCanceled()
        {
            _order.AddItem(_screen, 5);
            _order.AddItem(_mouse, 5);
            _order.Ship();
            _order.Cancel();

            foreach (var delivery in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, delivery.Status);
            }
        }
    }
}
