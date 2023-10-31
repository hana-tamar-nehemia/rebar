using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace rebar.Models
{
    [BsonIgnoreExtraElements]
    public class Order
    {
        private Guid _id;

        private List<OrderShake> _shakes;

        private decimal _totalPrice;

        private string _customerName;

        private DateTime _orderDate;

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
