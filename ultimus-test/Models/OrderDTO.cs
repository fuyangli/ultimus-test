using UltimusTest.Models.Enums;

namespace UltimusTest.Models
{
    public class OrderDTOIn
    {
        public List<int> Items { get; set; } = new List<int>();
        public string TimeOfDay { get; set; } = "";
        
    }

    public class OrderDTOOut
    {
        public List<string> Items { get; set; } = new List<string>();
        public string TimeOfDay { get; set; } = "";

    }
}
