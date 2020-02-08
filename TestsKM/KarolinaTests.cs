using NUnit.Framework;
using System;
using marekKarolinaProjekt;

namespace TestsKM
{

    [TestFixture]
    class KarolinaTests
    {


        [Test]
        public void Premium_Expect_15PercentDiscount()
        {
            Client premiumClient = new Client
            {
                ClientId = 1,
                ClientName = "Pamela",
                ClientType = ClientType.Premium
            };

            Order order = new Order
            {
                OrderId = 1,
                ProductId = 13,
                ProductQuantity = 1,
                Amount = 1000
            };

            SpecyficOrders clientOrderService = new SpecyficOrders();

            clientOrderService.ApplyDiscount(premiumClient, order);

            NUnit.Framework.Assert.AreEqual(order.Amount, 700);
        }

        [Test]
        public void Standard_Expect_NoDiscount()
        {
            Client standardClient = new Client
            {
                ClientId = 2,
                ClientName = "Fryderyk",
                ClientType = ClientType.Standard
            };

            Order order = new Order
            {
                OrderId = 2,
                ProductId = 212,
                ProductQuantity = 1,
                Amount = 3000
            };

            SpecyficOrders clientOrderService = new SpecyficOrders();

            clientOrderService.ApplyDiscount(standardClient, order);

            NUnit.Framework.Assert.AreEqual(order.Amount, 3000);
        }

        [Test]
        public void Special_Expect_30PercentDiscount()
        {
            Client specialClient = new Client
            {
                ClientId = 3,
                ClientName = "John",
                ClientType = ClientType.Special
            };

            Order order = new Order
            {
                OrderId = 3,
                ProductId = 2,
                ProductQuantity = 1,
                Amount = 10000
            };

            SpecyficOrders clientOrderService = new SpecyficOrders();

            clientOrderService.ApplyDiscount(specialClient, order);

            NUnit.Framework.Assert.AreEqual(order.Amount, 7000);
        }
    }
}
