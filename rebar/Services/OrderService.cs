using MongoDB.Driver;
using rebar.Models;

namespace rebar.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _order;

        public OrderService(IOrderDatabaseSettings settings, IMongoClient mongoClient)
        {

            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _order = database.GetCollection<Order>(settings.OrderCollectionName);

        }

        public List<Order> Get()
        {
            return _order.Find(order => true).ToList();
        }

        public Order Creat(Order order)
        {
            _order.InsertOne(order);
            return order;
        }

        public void Delete(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Order Get(Guid orderId)
        {
            return _order.Find(order => order.OrderId == orderId).FirstOrDefault();
        }

    }
}
