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
    }
}
