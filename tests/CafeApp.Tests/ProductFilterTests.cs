using Xunit;
using CafeApp.Services;
using CafeApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace CafeApp.Tests
{
    public class ProductFilterTests
    {
        [Fact]
        public void FilterByName_ReturnsMatchingProducts_WhenKeywordExists()
        {
            // Arrange
            var filter = new ProductFilter();
            var products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Black Coffee" },
                new Product { ProductId = 2, Name = "Milk Tea" }
            };

            // Act
            var result = filter.FilterByName(products, "Coffee");

            // Assert
            var listResult = result.ToList();
            Assert.Single(listResult);
            Assert.Equal("Black Coffee", listResult[0].Name);
        }

        [Fact]
        public void FilterByName_ReturnsEmpty_WhenNoMatchFound()
        {
            // Arrange
            var filter = new ProductFilter();
            var products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Black Coffee" }
            };

            // Act
            var result = filter.FilterByName(products, "Smoothie");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void FilterByName_ReturnsAllProducts_WhenKeywordIsNullEmptyOrWhitespace()
        {
            // Arrange
            var filter = new ProductFilter();
            var products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Black Coffee" },
                new Product { ProductId = 2, Name = "Milk Tea" }
            };

            // Act
            var resultNull = filter.FilterByName(products, null);
            var resultEmpty = filter.FilterByName(products, "");

            // Assert
            Assert.Equal(2, resultNull.Count());
            Assert.Equal(2, resultEmpty.Count());
        }

        [Fact]
        public void FilterByName_IsCaseInsensitive()
        {
            // Arrange
            var filter = new ProductFilter();
            var products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Cappuccino" }
            };

            // Act
            var result = filter.FilterByName(products, "cappuccino");

            // Assert
            Assert.Single(result);
        }
    }
}