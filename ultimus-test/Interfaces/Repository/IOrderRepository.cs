using UltimusTest.Models;

namespace UltimusTest.Interfaces.Repository
{
    public interface IOrderRepository
    {
        public List<Order> GetOrders();
        public void AddOrder(Order order);
    }
}
