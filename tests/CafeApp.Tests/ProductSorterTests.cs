using CafeApp.Models;
using CafeApp.Services;
using Xunit;

namespace CafeApp.Tests
{
    public class ProductSorterTests
    {
        private readonly ProductSorter _sorter = new ProductSorter();

        private List<Product> CreateProducts()
        {
            return new List<Product>
            {
                new Product { ProductId = 1, Name = "Tra sua", Price = 45000 },
                new Product { ProductId = 2, Name = "Americano", Price = 30000 },
                new Product { ProductId = 3, Name = "Capuchino", Price = 50000 }
            };
        }

        // Test 1: Sap xep gia tang dan
        [Fact]
        public void Sort_PriceAscending_ReturnsCorrectOrder()
        {
            var products = CreateProducts();

            var result = _sorter.Sort(products, "price_asc");

            Assert.Equal(
                new decimal?[] { 30000, 45000, 50000 },
                result.Select(p => p.Price)
            );
        }

        // Test 2: Sap xep gia giam dan
        [Fact]
        public void Sort_PriceDescending_ReturnsCorrectOrder()
        {
            var products = CreateProducts();

            var result = _sorter.Sort(products, "price_desc");

            Assert.Equal(
                new decimal?[] { 50000, 45000, 30000 },
                result.Select(p => p.Price)
            );
        }

        // Test 3: Sap xep ten A-Z
        [Fact]
        public void Sort_NameAscending_ReturnsCorrectOrder()
        {
            var products = CreateProducts();

            var result = _sorter.Sort(products, "name_asc");

            Assert.Equal(
                new string?[] { "Americano", "Capuchino", "Tra sua" },
                result.Select(p => p.Name)
            );
        }

        // Test 4: Danh sach rong
        [Fact]
        public void Sort_EmptyList_ReturnsEmptyList()
        {
            var products = new List<Product>();

            var result = _sorter.Sort(products, "price_asc");

            Assert.Empty(result);
        }

        // Test 5: Kiem tra danh sach khong bi thay doi khi sort mac dinh
        [Fact]
        public void Sort_DefaultOrder_ReturnsOriginalList()
        {
            var products = CreateProducts();

            var result = _sorter.Sort(products, "");

            Assert.Equal(products, result);
        }
    }
}