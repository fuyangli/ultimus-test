using UltimusTest.Models;

namespace UltimusTest.Interfaces.Service
{
    public interface IOrderService
    {
        public List<OrderDTOOut> GetOrders();
        public OrderDTOOut AddOrder(OrderDTOIn model);
    }
}
