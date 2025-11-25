using System;
using Xunit;
using Shop.Domain.Entities.ProductAgg.ValueObjects;
using Shop.Domain.Entities.ProductAgg;

namespace Shop.Tests.Domain.ProductAgg
{
    public class ProductAggregateTests
    {
        // ------------------------------
        // Create Product
        // ------------------------------

        [Fact]
        public void CreateProduct_ShouldCreateSuccessfully()
        {
            // Arrange
            var name = ProductName.Create("شامپو");
            var description = ProductDescription.Create("شامپو مخصوص موهای خشک");
            var price = ProductPrice.Create(120000);
            int stock = 10;
            Guid categoryId = Guid.NewGuid();

            // Act
            var product = new Product(name, description, price, stock, categoryId);

            // Assert
            Assert.Equal("شامپو", product.Name.Value);
            Assert.Equal("شامپو مخصوص موهای خشک", product.Description.Value);
            Assert.Equal(120000, product.Price.Value);
            Assert.Equal(10, product.Stock);
            Assert.Equal(categoryId, product.CategoryId);
        }

        // ------------------------------
        // Change Name
        // ------------------------------

        [Fact]
        public void ChangeName_ShouldUpdateProductName()
        {
            var product = CreateSampleProduct();
            var newName = ProductName.Create("نرم کننده");

            // Act
            product.ChangeName(newName.Value);

            // Assert
            Assert.Equal("نرم کننده", product.Name.Value);
        }

        // ------------------------------
        // Change Price
        // ------------------------------
        [Fact]
        public void ChangePrice_ShouldUpdatePrice()
        {
            var product = CreateSampleProduct();
            var newPrice = ProductPrice.Create(250000);

            // Act
            product.ChangePrice(newPrice.Value , "IRR");

            // Assert
            Assert.Equal(250000, product.Price.Value);
        }

        // ------------------------------
        // Decrease Stock
        // ------------------------------
        [Fact]
        public void DecreaseStock_ShouldReduceStock()
        {
            var product = CreateSampleProduct();

            // Act
            product.DecreaseStock(5);

            // Assert
            Assert.Equal(5, product.Stock);
        }

        [Fact]
        public void DecreaseStock_WhenMoreThanAvailable_ShouldThrowException()
        {
            var product = CreateSampleProduct();

            // Assert
            Assert.Throws<ArgumentException>(() => product.DecreaseStock(20));
        }

        // ------------------------------
        // Increase Stock
        // ------------------------------
        [Fact]
        public void IncreaseStock_ShouldAddStock()
        {
            var product = CreateSampleProduct();

            // Act
            product.IncreaseStock(10);

            // Assert
            Assert.Equal(20, product.Stock);
        }

        // ------------------------------
        // Validation Tests
        // ------------------------------
        [Fact]
        public void CreateProduct_WithNegativePrice_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var invalidPrice = ProductPrice.Create(-1);
            });
        }

        [Fact]
        public void CreateProduct_WithInvalidName_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var name = ProductName.Create("ا"); // کمتر از ۳ کاراکتر
            });
        }

        // ------------------------------
        // Helpers
        // ------------------------------
        private Product CreateSampleProduct()
        {
            return new Product(
                ProductName.Create("شامپو"),
                ProductDescription.Create("توضیحات تست"),
                ProductPrice.Create(100000),
                10,
                Guid.NewGuid());
        }

    }
}