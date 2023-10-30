using System;
using System.Collections.Generic;
using System.Linq;

namespace rebar.Models
{
    public class Order
    {
        private List<OrderShake> _shakes { get; set; } = new List<OrderShake>();
        private decimal _totalPrice { get; set; }
        private Guid _orderId { get; set; }
        private string _customerName { get; set; }
        private DateTime _orderDate { get; set; }
        private List<Discount> _discounts { get; set; } = new List<Discount>();
    }
}
