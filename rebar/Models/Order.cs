using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace rebar.Models
{
    public class Order
    {
        [BsonId]
        private Guid _id;

        [BsonElement("shakes")]
        private List<OrderShake> _shakes;

        [BsonElement("totalPrice")]
        private decimal _totalPrice;

        [BsonElement("customerName")]
        private string _customerName;

        [BsonElement("orderDate")]
        private DateTime _orderDate;

        [BsonElement("discounts")]
        private List<Discount> _discounts;

        public Order(List<OrderShake> shakes, decimal totalPrice, string customerName, DateTime orderDate, List<Discount> discounts)
        {
            _id = new Guid();
            _shakes = shakes;
            _totalPrice = totalPrice;
            _customerName = customerName;
            _orderDate = orderDate;
            _discounts = discounts;
        }
        public List<OrderShake> Shakes
        {
            get { return _shakes; }
            set { _shakes = value; }
        }

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                if (value >= 0)
                    _totalPrice = value;
            }
        }

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _customerName = value;
            }
        }

        public DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }

        public List<Discount> Discounts
        {
            get { return _discounts; }
            set { _discounts = value; }
        }

    }
}
