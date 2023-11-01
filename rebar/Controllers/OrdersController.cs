using Microsoft.AspNetCore.Mvc;
using rebar.Models;
using rebar.Services;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rebar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderServise;
        private readonly IShakeService _shakeService;

        public OrdersController(IOrderService orderService)
        {

            _orderServise = orderService;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return _orderServise.Get();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(string id)
        {
            var order = _orderServise.Get(id);

            if (order == null)
            {
                return NotFound($"order with id = {id} not found");
            }
            return order;
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            _orderServise.Creat(order);

            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] string value)
        {
            var order = _orderServise.Get(id);

            if (order == null)
            {
                return NotFound($"shake with id = {id} not found");
            }
            _orderServise.Delete(order.Id);

            return Ok($"order with id = {id} deleted");
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _orderServise.Delete(id);
        }

        //Type to send
        /*
         * {
         * "CustomerName" : "tamar",
         * shakes: [{"id": "2345678", "size": "Small"},{"id": "78989", "size": "Large"}]
         * discount ["description":"per one" , "percent" : 2]
         * }
         */
        [HttpPost]
        public ActionResult CreateOrder([FromBody] Order orderRequest)
        {

            //if the order is valid we open one
            if (orderRequest.CustomerName != null && orderRequest.Shakes.Count > 0 && orderRequest.Shakes.Count <= 10)
            {
               return openNewOrder(orderRequest);
            }
            //if the order not valid 
            if (orderRequest.CustomerName == null) { return BadRequest("enter name"); }
            if (orderRequest.Shakes.Count == 0) { return BadRequest("no shake to buy"); }
            if (orderRequest.Shakes.Count >10) { return BadRequest("too much shake to buy"); }

            return BadRequest("somthing wrong");
        }


        public ActionResult openNewOrder(Order orderRequest)
        {
            //order time begin
            DateTime orderBeginDate = new DateTime();
            orderBeginDate = DateTime.Now;

            //costumer name
            string customerName = orderRequest.CustomerName;

            //variable for Order
            List<OrderShake> orderShakes = new List<OrderShake>();
            decimal totalPrice = 0;

            foreach (var shakeData in orderRequest.Shakes)
            {
                string shakeId = shakeData.Id;
                string size = shakeData.Size;

                //find the shake in the DB and create ShakeOrders list for the Order
                Shake shake = _shakeService.Get(shakeId);
                if (shake != null)
                {
                    var shakeName = shake.Name;
                    var shakePrice = shake.getPriceBySize(size);
                    var orderShake = new OrderShake(shakeId, shakeName, size, shakePrice);
                    orderShakes.Add(orderShake);

                    //calcuate the total price
                    if (orderRequest.Discounts != null)
                    {
                        totalPrice += discountHandle(shakePrice, orderRequest);
                    }
                    else
                    {
                        totalPrice += shakePrice;
                    }
                }
            }
            
            Order order = new Order(orderShakes, totalPrice, customerName, orderBeginDate, null);
           
            _orderServise.Creat(order);

            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }


    // manage all the discount(for now is like just one type of discount)
       public decimal discountHandle(decimal price, Order orderRequest)
        {
            if (orderRequest.Discounts.Description == "per one")
            {
                return price - (price * (orderRequest.Discounts.DiscountPercent / 100));
            }
            //need to reaplase with exption
            return price;
        }
    }
}
