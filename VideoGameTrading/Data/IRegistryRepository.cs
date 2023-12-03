using VideoGameTrading.Models;
using System.Net.Http.Headers;

namespace VideoGameTrading.Data {
    public interface IRegistryRepository {
        public List<Item> GetItems();

        public Item GetItemById(int id);

        public int StoreItem(Item item);
    }
}
