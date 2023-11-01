using rebar.Models;

namespace rebar.Services
{
    public interface IOrderService
    {
        List<Order> Get();
        Order Get(string OrderId);
        Order Creat(Order order);
        void Delete(string orderId);
    }
}
