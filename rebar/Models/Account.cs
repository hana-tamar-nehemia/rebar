using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace rebar.Models
{
    public class Account
    {
        private List<Order> _orders { get; set; } = new List<Order>();
        private decimal _totalOrderPrice { get; set; }


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
