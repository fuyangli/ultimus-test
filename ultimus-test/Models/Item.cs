using UltimusTest.Models.Enums;

namespace UltimusTest.Models
{
    public class Item
    {
        public string Name { get;set; }
        public string? Description { get;set; }
        public bool Reorderable { get; set; }

        public DishType DishType { get; set; }
        public TimeOfDay TimeOfDay { get; set; }

        public Item(string name, DishType dishType, TimeOfDay timeOfDay, string? description = null, bool reorderable = false)
        {
            Name = name;
            Description = description;
            Reorderable = reorderable;
            DishType = dishType;
            TimeOfDay = timeOfDay;
        }
    }
}
