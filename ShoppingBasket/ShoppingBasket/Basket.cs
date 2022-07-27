using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket
{
    public class Basket
    {
        private List<Item> items;

        public Basket(List<Item> items)
        {
            this.items = items;
        }

        public decimal Total => items.Sum(i => SubTotal(i));

        private static decimal SubTotal(Item i)
        {
            return i.Price * i.Amount;
        }
    }
}
