using NUnit.Framework;
using System;
using marekKarolinaProjekt;

namespace TestsKM
{
    [TestFixture]
    class MarekTests
    {




        [Test]
        public void Price_Test_Price_Negative_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(
            () =>
            {
                new CurrencyAndPrice(-10, Currency.EURO);
            }
            );
        }

        [Test]
        public void Price_Test_Converting_To_PLN()
        {
            var price = new CurrencyAndPrice(10.10, Currency.EURO);

            Assert.AreEqual(price.InPLN().Value, 38.38);
            Assert.AreEqual(price.InEURO().Value, 10.10);
        }

        [Test]
        public void Price_Test_Converting_To_EURO()
        {
            var price = new CurrencyAndPrice(100, Currency.PLN);

            Assert.AreEqual(price.InPLN().Value, 100);
            Assert.AreEqual(price.InEURO().Value, 23.42);
        }


        [Test]
        public void When_PremiumClient_Expect_15PercentDiscount()
        {
            Client premiumClient = new Client
            {
                ClientId = 1,
                ClientName = "Marek",
                ClientType = ClientType.Premium
            };

            Order order = new Order
            {
                OrderId = 1,
                ProductId = 212,
                ProductQuantity = 1,
                Amount = 1000
            };

            SpecyficOrders customerOrderService = new SpecyficOrders();

            customerOrderService.ApplyDiscount(premiumClient, order);

            NUnit.Framework.Assert.AreEqual(order.Amount, 850);
        }





        [Test]
        public void When_BasicCustomer_Expect_NoDiscount()
        {
            Client basicCustomer = new Client
            {
                ClientId = 2,
                ClientName = "Karolajn",
                ClientType = ClientType.Standard
            };

            Order order = new Order
            {
                OrderId = 2,
                ProductId = 212,
                ProductQuantity = 1,
                Amount = 210
            };

            SpecyficOrders customerOrderService = new SpecyficOrders();

            customerOrderService.ApplyDiscount(basicCustomer, order);

            NUnit.Framework.Assert.AreEqual(order.Amount, 210);
        }




    }
}
