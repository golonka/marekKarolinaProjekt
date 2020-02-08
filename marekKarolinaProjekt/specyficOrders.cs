
namespace marekKarolinaProjekt
{
    public class SpecyficOrders
    {
        public void ApplyDiscount(Client client, Order order)
        {
            if (client.ClientType == ClientType.Premium)
            {
                order.Amount = order.Amount - ((order.Amount * 15) / 100);
            }
            else if (client.ClientType == ClientType.Special)
            {
                order.Amount = order.Amount - ((order.Amount * 30) / 100);
            }
        }
    }
}
