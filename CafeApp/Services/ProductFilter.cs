using CafeApp.Models;
namespace CafeApp.Services
{
    public class ProductFilter
    {
        // Hàm lọc danh sách món ăn theo tên (không phân biệt hoa/thường)
        public IEnumerable<Product> FilterByName(IEnumerable<Product> products, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return products;
            }

            return products.Where(p => p.Name != null && 
                p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }
    }
}