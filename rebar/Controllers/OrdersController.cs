using Microsoft.AspNetCore.Mvc;
using rebar.Models;
using rebar.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rebar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
            private readonly IOrderService orderServise;

            public OrdersController(IOrderService orderService)
            {

                this.orderServise = orderService;
            }

            // GET: api/<OrdersController>
            [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return orderServise.Get();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(Guid id)
        {
            var order = orderServise.Get(id);

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
            orderServise.Creat(order);

            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] string value)
        {
            var order = orderServise.Get(id);

            if(order == null)
            {
                return NotFound($"shake with id = {id} not found");
            }
            orderServise.Delete(order.Id);

            return Ok($"order with id = {id} deleted");
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            orderServise.Delete(id);
        }
    }
}
