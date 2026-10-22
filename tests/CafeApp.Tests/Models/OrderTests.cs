using CafeApp.Models;

namespace CafeApp.Tests.Models
{
    /// <summary>
    /// Issue #10 [C1] — Các test đầu tiên cho model Order.
    /// </summary>
    public class OrderTests
    {
        [Fact]
        public void NewOrder_IsServed_IsFalse()
        {
            // Arrange + Act
            var order = new Order();

            // Assert
            Assert.False(order.IsServed);
        }

        [Fact]
        public void NewOrder_IsPaid_IsFalse()
        {
            var order = new Order();

            Assert.False(order.IsPaid);
        }

        [Fact]
        public void TotalPrice_SetAndGetRoundTrips()
        {
            var order = new Order
            {
                TotalPrice = 25000m
            };

            Assert.Equal(25000m, order.TotalPrice);
        }
    }
}
