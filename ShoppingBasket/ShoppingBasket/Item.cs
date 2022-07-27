namespace ShoppingBasket
{
    public class Item
    {
        public Item(decimal price, int amount = 1)
        {
            Price = price;
            Amount = amount;
        }

        public decimal Price { get; }

        public int Amount { get; }
    }
}