namespace GuitarShack
{
    public interface IProductSalesHistory
    {
        int GetSalesInLast30Days(int productId);
    }
}