namespace GuitarShack
{
    public class RestockLevelCalculator : IRestockLevelCalculator
    {
        private IProductSalesHistory history;
        private IProductInfo productInfo;

        public RestockLevelCalculator(IProductSalesHistory history, IProductInfo productInfo)
        {
            this.history = history;
            this.productInfo = productInfo;
        }

        public int GetRestockLevel(int productId)
        {
            var sales = history.GetSalesInLast30Days(productId);
            var ledTime = productInfo.GetLedTime(productId);

            return ledTime * sales / 30;
        }
    }
}