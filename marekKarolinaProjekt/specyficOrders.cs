
namespace marekKarolinaProjekt
{
    public class SpecyficOrders
    {
        public void ApplyDiscount(Client client, Order order)
        {
            if (client.ClientType == ClientType.Premium)
            {
                order.Amount = order.Amount - ((order.Amount * 10) / 100);
            }
            else if (client.ClientType == ClientType.SpecialClient)
            {
                order.Amount = order.Amount - ((order.Amount * 20) / 100);
            }
        }
    }
}
