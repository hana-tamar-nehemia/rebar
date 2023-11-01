using Microsoft.Extensions.Options;
using MongoDB.Driver;
using rebar.Models;

namespace rebar.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _orderCollection;
        private readonly IOptions<DatabaseSettings> _settings;
        public OrderService(IOptions<DatabaseSettings> settings)
        {
            _settings = settings;

            var mongoClient = new MongoClient(_settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_settings.Value.DatabaseName);
            _orderCollection = mongoDatabase.GetCollection<Order>
                (_settings.Value.OrderCollectionName);
        }

        public List<Order> Get()
        {
            return _orderCollection.Find(order => true).ToList();
        }

        public Order Creat(Order order)
        {
            _orderCollection.InsertOne(order);
            return order;
        }

        public void Delete(string orderId)
        {
            throw new NotImplementedException();
        }

        public Order Get(string orderId)
        {
            return _orderCollection.Find(order => order.Id == orderId).FirstOrDefault();
        }

    }
}
