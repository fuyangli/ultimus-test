using UltimusTest.Interfaces.Repository;
using UltimusTest.Models;
using UltimusTest.Models.Enums;

namespace UltimusTest.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private List<Item> _items;

        public ItemRepository()
        {
            _items = new List<Item>()
            {
                new Item("Error",   DishType.None,      TimeOfDay.Unknown),
                new Item("Eggs",    DishType.Entree,    TimeOfDay.Morning),
                new Item("Toast",   DishType.Side,      TimeOfDay.Morning),
                new Item("Coffee",  DishType.Drink,     TimeOfDay.Morning,  reorderable:true),
                new Item("Steak",   DishType.Entree,    TimeOfDay.Night),
                new Item("Potato",  DishType.Side,      TimeOfDay.Night,    reorderable:true),
                new Item("Wine",    DishType.Drink,     TimeOfDay.Night),
                new Item("Cake",    DishType.Dessert,   TimeOfDay.Night),

            };
        }

        public List<Item> GetItems()
        {
            return _items;
        }

        // We also can create Items and put them on the database, but for this propurse, I'll act like this is a Enum
    }
}
