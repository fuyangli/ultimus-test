using System.ComponentModel;

namespace UltimusTest.Models.Enums
{
    // If I was to use an database, I'd made this a Class with Id and Name so I can retrive it from the db
    // But for now, I'm going to use Enums and retrive the Description 
    public enum DishType
    {
        [Description("None")]
        None = 0,
        [Description("Entreé")]
        Entree = 1,
        [Description("Side")]
        Side = 2,
        [Description("Drink")]
        Drink = 3,
        [Description("Dessert")]
        Dessert = 4
    }
}
