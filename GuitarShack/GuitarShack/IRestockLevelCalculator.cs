namespace GuitarShack
{
    public interface IRestockLevelCalculator
    {
        int GetRestockLevel(int productId);
    }
}