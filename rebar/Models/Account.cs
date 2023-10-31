using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace rebar.Models
{
    [BsonIgnoreExtraElements]
    public class Account
    {
        private List<Order> _orders;

        private decimal _totalOrderPrice;

       public Account(List<Order> orders, decimal totalOrderPrice)
        {
            _orders = orders;
            _totalOrderPrice = totalOrderPrice;
        }

        // Property for _orders
        public List<Order> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        // Property for _totalOrderPrice
        public decimal TotalOrderPrice
        {
            get { return _totalOrderPrice; }
            set { _totalOrderPrice = value; }
        }
    }
}
