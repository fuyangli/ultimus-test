using UltimusTest.Models.Enums;

namespace UltimusTest.Models
{
    public class Order
    {
        public List<Item> Items { get; set; }
        public TimeOfDay TimeOfDay { get; set; }

        public Order(TimeOfDay timeOfDay, List<Item> items)
        {
            TimeOfDay = timeOfDay;
            Items = items;
            
        }


    }
}
