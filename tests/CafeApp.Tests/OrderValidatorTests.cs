using Xunit;
using CafeApp.Services;

namespace CafeApp.Tests
{
    public class OrderValidatorTests
    {
        [Theory]
        [InlineData(1, "Nguyen Van A", true)]
        [InlineData(5, "Valid Name", true)]
        [InlineData(0, "Nguyen Van A", false)] // Số bàn <= 0 (Không hợp lệ)
        [InlineData(-1, "Nguyen Van A", false)] // Số bàn âm (Không hợp lệ)
        [InlineData(1, "", false)] // Tên rỗng
        [InlineData(1, null, false)] // Tên null
        [InlineData(1, "   ", false)] // Tên toàn khoảng trắng
        public void ValidateOrderInput_ReturnsExpectedIsValid(int tableNumber, string customerName, bool expectedIsValid)
        {
            // Act
            var result = OrderValidator.ValidateOrderInput(tableNumber, customerName);

            // Assert
            Assert.Equal(expectedIsValid, result.IsValid);
        }

        [Fact]
        public void ValidateOrderInput_ReturnsFalse_WhenCustomerNameExceeds50Characters()
        {
            // Arrange (Tạo tên dài 51 ký tự)
            string longName = new string('A', 51);

            // Act
            var result = OrderValidator.ValidateOrderInput(1, longName);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(Messages.CustomerNameTooLong, result.ErrorMessage);
        }
    }
}