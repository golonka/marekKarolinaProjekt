﻿using NUnit.Framework;
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


        //Client service
        [Test]
        public void When_PremiumClient_Expect_10PercentDiscount()
        {
            //Arrange
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
                Amount = 150
            };

            SpecyficOrders customerOrderService = new SpecyficOrders();

            //Act
            customerOrderService.ApplyDiscount(premiumClient, order);

            //Assert
            NUnit.Framework.Assert.AreEqual(order.Amount, 135);
        }





        [Test]
        public void When_BasicCustomer_Expect_NoDiscount()
        {
            //Arrange
            Client basicCustomer = new Client
            {
                ClientId = 2,
                ClientName = "Karolajn",
                ClientType = ClientType.Normal
            };

            Order order = new Order
            {
                OrderId = 2,
                ProductId = 212,
                ProductQuantity = 1,
                Amount = 210
            };

            SpecyficOrders customerOrderService = new SpecyficOrders();

            //Act
            customerOrderService.ApplyDiscount(basicCustomer, order);

            //Assert
            NUnit.Framework.Assert.AreEqual(order.Amount, 210);
        }




    }
}
