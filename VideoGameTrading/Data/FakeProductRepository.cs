using Microsoft.EntityFrameworkCore;
using VideoGameTrading.Models;

namespace VideoGameTrading.Data {
    public class FakeProductRepository : IProductRepository {
        readonly List<Item> items = new();

        public Item GetItemById(int id) => throw new NotImplementedException();

        public List<Item> GetItems() => throw new NotImplementedException();

        public int StoreItem(Item item) {
            item.ItemId = items.Count + 1;
            items.Add(item);

            return item.ItemId;
        }

        //public int UpdateItem(Item item) {
        //    items[item.ItemId - 1].InCart = item.InCart;

        //    return item.InCart;
        //}
    }
}
