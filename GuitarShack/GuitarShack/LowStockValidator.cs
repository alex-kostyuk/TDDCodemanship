using System;

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
            var stockLevelIsLow = stockLevel - quantity <= restockLevel;
            if (stockLevelIsLow)
            {
                string message = $"Please order more of product {productId}";
                alertSender.SendMessage(message);
            }
        }
    }
}