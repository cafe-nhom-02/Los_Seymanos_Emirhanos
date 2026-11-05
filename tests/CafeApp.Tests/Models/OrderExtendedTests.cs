using CafeApp.Models;

namespace CafeApp.Tests.Models
{
    /// <summary>
    /// Issue #13 [C4] — Unit test bổ sung cho model Order (mở rộng từ C1).
    /// Kiểm tra các thuộc tính chưa được phủ bởi test cũ.
    /// </summary>
    public class OrderExtendedTests
    {
        [Fact]
        public void NewOrder_TableNo_AllowsNull()
        {
            // Đơn "rác" tạm thời (trước khi khách chọn bàn) có TableNo = null
            var order = new Order { TableNo = null };

            Assert.Null(order.TableNo);
        }

        [Fact]
        public void NewOrder_CustomerName_AllowsNull()
        {
            var order = new Order { CustomerName = null };

            Assert.Null(order.CustomerName);
        }

        [Fact]
        public void Order_OrderDate_RoundTrips()
        {
            var now = new DateTime(2026, 11, 3, 9, 30, 0);
            var order = new Order { OrderDate = now };

            Assert.Equal(now, order.OrderDate);
        }

        [Fact]
        public void NewOrder_TotalPrice_IsZero()
        {
            // decimal mặc định là 0 — đơn mới chưa có sản phẩm thì chưa có tổng tiền
            var order = new Order();

            Assert.Equal(0m, order.TotalPrice);
        }
    }
}
