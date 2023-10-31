using rebar.Models;

namespace rebar.Services
{
    public interface IOrderService
    {
        List<Order> Get();
        Order Get(Guid OrderId);
        Order Creat(Order order);
        void Delete(Guid orderId);
    }
}
