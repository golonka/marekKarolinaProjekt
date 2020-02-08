using NUnit.Framework;
using System;
using marekKarolinaProjekt;

namespace TestsKM
{

    [TestFixture]
    class KarolinaTests
    {


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


        [Test]
        public void Specyfication_Empty_String_Negative_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(
            () =>
            {
                new Specyfication(
                   "","","",""
                );
            }
            );
        }

        [Test]
        public void Specyfication_Low_Standard_New_Order()
        {
            Specyfication lowStandard = new Specyfication(

                "8",
                "Nvidia",
                "abc",
                "dfe"
            );

            Order order = new Order
            {
                OrderId = 15,
                ProductId = 500,
                ProductQuantity = 1,
                Amount = 500
            };

        }

        [Test]
        public void Specyfication_Medium_Standard_New_Order()
        {
            Specyfication lowStandard = new Specyfication(

                "16",
                "Nvidia",
                "hhh",
                "yyy"
            );

            Order order = new Order
            {
                OrderId = 17,
                ProductId = 515,
                ProductQuantity = 1,
                Amount = 4000
            };

        }
    }
}
