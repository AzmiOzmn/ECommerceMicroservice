using StackExchange.Redis;

namespace ECommerce.Basket.Services
{
    public class RedisService
    {
        private string Host { get; set; }
        private int Port { get; set; }
        private ConnectionMultiplexer Redis { get; set; }

        public RedisService(int port, string host)
        {
            Port = port;
            Host = host;
           
        }

        public void Connect() => Redis = ConnectionMultiplexer.Connect($"{Host}:{Port}");

        public IDatabase GetDb(int db=1) => Redis.GetDatabase(db);


    }
}
