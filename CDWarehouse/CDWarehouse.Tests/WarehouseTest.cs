using NUnit.Framework;
using System.Collections.Generic;

namespace CDWarehouse
{
    public class WarehouseTest
    {
        [Test]
        public void AddStockToWarehouse()
        {
            Item item = new Item(artist: "AC/DC", title: "Back in Black");
            Warehouse warehouse = new Warehouse(new List<Item> { item });

            warehouse.AddStock(artist: "AC/DC", title: "Back in Black", quantity: 10);

            Assert.That(item.StockLevel, Is.EqualTo(10)) ;
        }

        [Test]
        public void SearchInWarehouse()
        {
            Warehouse warehouse = new Warehouse(new List<Item>
            {
                new Item(artist: "AC/DC", title:"Back in Black"),
                new Item(artist: "AC/DC", title:"The razors edge"),
                new Item(artist: "Metallica", title:"The Black Album"),
            });
            var result = warehouse.Search(input: "AC/DC Black");
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void BuyCd()
        {
            Item item = new Item(artist: "AC/DC", title: "Back in Black", quantity: 10);
            Warehouse warehouse = new Warehouse(new List<Item> { item });

            warehouse.BuyCD(artist: "AC/DC", title: "Back in Black", quantity: 2);

            Assert.That(item.StockLevel, Is.EqualTo(8));
        }

        [Test]
        public void ReviewCd()
        {
            var item = new Item(artist: "AC/DC", title: "Back in Black");

            Warehouse warehouse = new Warehouse(new List<Item> { item });

            warehouse.RateCD(artist: "AC/DC", title: "Back in Black", rating: 9);

            Assert.That(item.Rating, Is.EqualTo(5));
        }
    }
}