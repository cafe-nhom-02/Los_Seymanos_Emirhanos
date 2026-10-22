using CafeApp.Models;

namespace CafeApp.Tests.Models
{
    /// <summary>
    /// Issue #10 [C1] — Các test đầu tiên cho model Product.
    /// </summary>
    public class ProductTests
    {
        [Fact]
        public void Price_AllowsNull()
        {
            var product = new Product { Name = "Coffee", Price = null };

            Assert.Null(product.Price);
        }

        [Fact]
        public void Price_SetAndGetRoundTrips()
        {
            var product = new Product
            {
                Name = "Espresso",
                Price = 12000m
            };

            Assert.Equal(12000m, product.Price);
        }

        [Fact]
        public void Name_AllowsNull()
        {
            var product = new Product { Name = null };

            Assert.Null(product.Name);
        }
    }
}
