using VideoGameTrading.Models;

namespace VideoGameTrading.Data {
    public class FakeRegistryRepository : IRegistryRepository {
        readonly List<Item> items = new();

        public Item GetItemById(int id) => throw new NotImplementedException();

        public List<Item> GetItems() => throw new NotImplementedException();

        public int StoreItem(Item item) {
            item.ItemId = items.Count + 1;
            items.Add(item);

            return item.ItemId;
        }
    }
}
