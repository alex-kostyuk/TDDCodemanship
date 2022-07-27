using Moq;
using NUnit.Framework;

namespace GuitarShack.Tests
{
    public class GuitarShackTest
    {

        [Test]
        public void MessageIsSentTest()
        {
            const int testProductId = 811;
            const int testStockLevel = 25;
            const int testRestockLevel = 24;
            const int testQuantity = 1;
            const string testMessage = "Please order more of product 811";

            var productInfoMock = new Mock<IProductInfo>();
            productInfoMock.Setup(x => x.GetStockLevel(testProductId)).Returns(testStockLevel);

            var restockLevelCalculatorMock = new Mock<IRestockLevelCalculator>();
            restockLevelCalculatorMock.Setup(x => x.GetRestockLevel(testProductId)).Returns(testRestockLevel);
            
            var alertSenderMock = new Mock<IAlertSender>();

            var lowStockValidator = new LowStockValidator(
                productInfoMock.Object,
                restockLevelCalculatorMock.Object,
                alertSenderMock.Object);

            lowStockValidator.BuyProduct(productId: testProductId, quantity: testQuantity);

            alertSenderMock.Verify(sender => sender.SendMessage(testMessage));
        }

        [Test]
        public void MessageIsNotSentTest()
        {
            const int testProductId = 811;
            const int testStockLevel = 26;
            const int testRestockLevel = 24;
            const int testQuantity = 1;

            var productInfoMock = new Mock<IProductInfo>();
            productInfoMock.Setup(x => x.GetStockLevel(testProductId)).Returns(testStockLevel);

            var restockLevelCalculatorMock = new Mock<IRestockLevelCalculator>();
            restockLevelCalculatorMock.Setup(x => x.GetRestockLevel(testProductId)).Returns(testRestockLevel);

            var alertSenderMock = new Mock<IAlertSender>();

            var lowStockValidator = new LowStockValidator(
                productInfoMock.Object,
                restockLevelCalculatorMock.Object,
                alertSenderMock.Object);

            lowStockValidator.BuyProduct(productId: testProductId, quantity: testQuantity);

            alertSenderMock.Verify(sender => sender.SendMessage( It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void CalculateRestockLevel()
        {
            const int testProductId = 811;
            const int testSales = 15;
            const int testLedTime = 14;

            const int expectedRestockLevel = 7;

            var productSalesHistoryMock = new Mock<IProductSalesHistory>();
            productSalesHistoryMock.Setup(x => x.GetSalesInLast30Days(testProductId)).Returns(testSales);

            var productInfoMock = new Mock<IProductInfo>();
            productInfoMock.Setup(x => x.GetLedTime(testProductId)).Returns(testLedTime);

            IRestockLevelCalculator restockLevelCalculator = new RestockLevelCalculator(
                productSalesHistoryMock.Object,
                productInfoMock.Object);
            var result = restockLevelCalculator.GetRestockLevel(testProductId);

            Assert.That(result, Is.EqualTo(expectedRestockLevel));
        }
    }
}