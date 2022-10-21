using UltimusTest.Models.Enums;
using UltimusTest.Models;
using UltimusTest.Repositories;
using UltimusTest.Interfaces.Repository;
using UltimusTest.Interfaces.Service;
using UltimusTest.Utils;
using System.Linq;

namespace UltimusTest.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IItemRepository _itemRepository;

        public OrderService(IOrderRepository orderRepository, IItemRepository itemRepository)
        {
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
        }

        public List<OrderDTOOut> GetOrders()
        {
            var orders =  _orderRepository.GetOrders();
            var items = _itemRepository.GetItems();

            var ordersModel = new List<OrderDTOOut>();

            ordersModel = orders.Select(x =>
            {
                return FromOrder(x);
            }).ToList();

            return ordersModel;
        }

        private OrderDTOOut FromOrder(Order order)
        {
            return new OrderDTOOut()
            {
                TimeOfDay = order.TimeOfDay.GetDescription(),
                Items = order.Items.Select(y => y.Name).ToList()
            };
        }

        public OrderDTOOut AddOrder(OrderDTOIn model)
        {
            var items = _itemRepository.GetItems();
            // I could use an Mapper too
            var timeOfDay = (TimeOfDay)Enum.Parse(typeof(TimeOfDay), model.TimeOfDay, true);
            var itemsInModel = items.Where(x => model.Items.Any(y => y == (int)x.DishType) && timeOfDay == x.TimeOfDay).ToList();
            var dishesType = Enum.GetValues(typeof(DishType)).Cast<DishType>();
            //var itemsOutOfScopeInModel = model.Items.Where(x => !dishesType.Contains((DishType)x));

            var order = new Order(timeOfDay, new List<Item>());

            foreach(var itemModelGroup in model.Items.GroupBy(x => x).OrderBy(x => x.Key))
            {
                var item = items.FirstOrDefault(x => x.DishType == (DishType)itemModelGroup.FirstOrDefault() && x.TimeOfDay == timeOfDay);
                var newItemOrder = new Item("", DishType.None, TimeOfDay.Unknown);
                if (item == null)
                {
                    newItemOrder.Name = $"Não há items para o ID: {itemModelGroup.Key}";
                    order.Items.Add(newItemOrder);
                    continue;
                }
                var groupCount = itemModelGroup.Count();
                if (groupCount > 1 && !item.Reorderable)
                {
                    newItemOrder.Name = $"You can't ask for more than one {item.Name}";
                    newItemOrder.DishType = item.DishType;
                    newItemOrder.TimeOfDay = item.TimeOfDay;
                    order.Items.Add(newItemOrder);
                    continue;
                }

                newItemOrder.Name = $"{item.Name}";
                if(groupCount > 1)
                {
                    newItemOrder.Name += $" (x{groupCount})";
                }
                newItemOrder.DishType = item.DishType;
                newItemOrder.TimeOfDay = item.TimeOfDay;
                newItemOrder.Reorderable = item.Reorderable;
                order.Items.Add(newItemOrder);

            }

            order.Items = order.Items.OrderBy(x => (int)x.DishType).ToList();

            _orderRepository.AddOrder(order);

            return FromOrder(order);

        }

    }

}
