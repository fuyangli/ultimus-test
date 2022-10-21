using UltimusTest.Models;

namespace UltimusTest.Interfaces.Repository
{
    public interface IItemRepository
    {
        public List<Item> GetItems();
    }
}
