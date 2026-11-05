using CafeApp.Models;

namespace CafeApp.Services
{
    public class ProductSorter
    {
        public List<Product> Sort(List<Product> products, string sortOrder)
        {
            return sortOrder switch
            {
                "price_asc" => products.OrderBy(p => p.Price).ToList(),
                "price_desc" => products.OrderByDescending(p => p.Price).ToList(),
                "name_asc" => products.OrderBy(p => p.Name).ToList(),
                _ => products
            };
        }
    }
}