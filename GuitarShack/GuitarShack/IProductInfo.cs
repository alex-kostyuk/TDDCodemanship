namespace GuitarShack
{
    public interface IProductInfo
    {
        int GetStockLevel(int productId);
        int GetLedTime(int productId);
    }
}