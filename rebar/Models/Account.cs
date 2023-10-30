using System;
using System.Collections.Generic;
using System.Linq;

namespace rebar.Models
{
    public class Account
    {
        private List<Order> _orders { get; set; } = new List<Order>();
        private decimal _totalOrderPrice { get; set; }
    }
}
