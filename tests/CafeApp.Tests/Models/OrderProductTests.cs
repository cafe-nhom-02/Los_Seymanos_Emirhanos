using CafeApp.Models;

namespace CafeApp.Tests.Models
{
    /// <summary>
    /// Issue #13 [C4] — Unit test bổ sung cho model OrderProduct.
    /// </summary>
    public class OrderProductTests
    {
        [Fact]
        public void NewOrderProduct_Quantity_IsZero()
        {
            // Arrange + Act
            var orderProduct = new OrderProduct();

            // Assert — int mặc định là 0
            Assert.Equal(0, orderProduct.Quantity);
        }

        [Fact]
        public void OrderProduct_Quantity_RoundTrips()
        {
            var orderProduct = new OrderProduct
            {
                OrderId = 10,
                ProductId = 20,
                Quantity = 3
            };

            Assert.Equal(3, orderProduct.Quantity);
        }

        [Fact]
        public void OrderProduct_ForeignKeyIds_RoundTrips()
        {
            var orderProduct = new OrderProduct
            {
                OrderId = 10,
                ProductId = 20
            };

            Assert.Equal(10, orderProduct.OrderId);
            Assert.Equal(20, orderProduct.ProductId);
        }
    }
}
