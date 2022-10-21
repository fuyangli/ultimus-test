using UltimusTest.Interfaces.Repository;
using UltimusTest.Models;

namespace UltimusTest.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private List<Order> _orders;

        public OrderRepository()
        {
            _orders = new List<Order>();
        }

       // If I was to use an database, here I'd get those orders from the database
        public List<Order> GetOrders()
        {
            return _orders;
        }

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }
    }
}
