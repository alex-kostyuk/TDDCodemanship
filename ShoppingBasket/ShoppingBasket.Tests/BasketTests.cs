using NUnit.Framework;
using ShoppingBasket;
using System.Collections.Generic;

namespace ShoppinBasket.Test
{
    public class BasketTests
    {
        [Test]
        public void BasketEmptyTotal()
        {
            Basket basket = new Basket(new List<Item>());
            Assert.That(basket.Total, Is.EqualTo(0m));
        }

        [Test]
        public void BasketSingleTotal()
        {
            Basket basket = new Basket(new List<Item>() { new Item(100m) });
            Assert.That(basket.Total, Is.EqualTo(100m));
        }

        [Test]
        public void BasketTwoItemsTotal()
        {
            Basket basket = new Basket(new List<Item> { new Item(100m), new Item(50m)});
            Assert.That(basket.Total, Is.EqualTo(150m));
        }

        [Test]
        public void BasketWithAmount()
        {
            Basket basket = new Basket(new List<Item> { new Item(100m, 2) });
            Assert.That(basket.Total, Is.EqualTo(200m));
        }
    }
}