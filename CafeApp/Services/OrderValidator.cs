namespace CafeApp.Services
{
    public class OrderValidator
    {
        public static (bool IsValid, string ErrorMessage) ValidateOrderInput(int tableNumber, string customerName)
        {
            // Kiểm tra số bàn lớn hơn 0
            if (tableNumber <= 0)
            {
                return (false, Messages.InvalidTableNumber);
            }

            // Kiểm tra tên khách không rỗng
            if (string.IsNullOrWhiteSpace(customerName))
            {
                return (false, Messages.EmptyCustomerName);
            }

            // Kiểm tra độ dài tên khách tối đa 50 ký tự
            if (customerName.Trim().Length > 50)
            {
                return (false, Messages.CustomerNameTooLong);
            }

            return (true, string.Empty);
        }
    }
}