
namespace marekKarolinaProjekt
{

    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public ClientType ClientType { get; set; }
    }

    public enum ClientType
    {
        Standard,
        Premium,
        Special
    }

 
}
