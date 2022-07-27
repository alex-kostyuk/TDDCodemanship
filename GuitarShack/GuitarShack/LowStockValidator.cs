namespace GuitarShack
{
    public class LowStockValidator
    {
        private IProductInfo productInfo;
        private IRestockLevelCalculator restockLevelCalculator;
        private IAlertSender alertSender;

        public LowStockValidator(IProductInfo productInfo, IRestockLevelCalculator restockLevelCalculator, IAlertSender alertSender)
        {
            this.productInfo = productInfo;
            this.restockLevelCalculator = restockLevelCalculator;
            this.alertSender = alertSender;
        }

        public void BuyProduct(int productId, int quantity)
        {
            var stockLevel = productInfo.GetStockLevel(productId);
            var restockLevel = restockLevelCalculator.GetRestockLevel(productId);

            // Examle:
            // 30 in storage
            // 25 in stock
            // 1 quantity in order
            // 24 - actual stock
            // 7 restockLevel 
            // 6 + 7 == 13 places in storage 
            // 10 - minimal order 
            // if (13 <  10) then send message  

            var stockLevelIsLow = stockLevel - quantity <= restockLevel;
            if (stockLevelIsLow)
            {
                string message = $"Please order more of product {productId}";
                alertSender.SendMessage(message);
            }
        }
    }
}