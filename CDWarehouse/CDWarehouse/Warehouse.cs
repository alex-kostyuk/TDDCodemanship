using System.Collections.Generic;
using System.Linq;

namespace CDWarehouse
{
    public class Warehouse
    {
        private IList<Item> list;

        public Warehouse(IList<Item> list)
        {
            this.list = list;
        }

        public void AddStock(string artist, string title, int quantity)
        {
            var item = GetItem(artist, title);
            item.StockLevel += quantity;
        }

        public IList<Item> Search(string input)
        {
            return new List<Item> { new Item(string.Empty, string.Empty)};
        }

        public void BuyCD(string artist, string title, int quantity)
        {
            var item = GetItem(artist, title);
            item.StockLevel -= quantity;
        }

        Item GetItem(string artist, string title)
        {
            return list.Where(i => i.Artist == artist && i.Title == title).First();
        }

        public void RateCD(string artist, string title, int rating)
        {
            var item = GetItem(artist, title);

            item.UpdateRating(rating);
        }
    }

}
