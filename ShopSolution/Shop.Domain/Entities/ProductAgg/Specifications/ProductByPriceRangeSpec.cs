using Shop.Domain.Commons;
using System.Linq.Expressions;

namespace Shop.Domain.Entities.ProductAgg.Specifications
{
    public class ProductByPriceRangeSpec : Specification<Product>
    {
        private readonly decimal _minPrice;
        private readonly decimal _maxPrice;

        public ProductByPriceRangeSpec(decimal minPrice, decimal maxPrice)
        {
            _minPrice = minPrice;
            _maxPrice = maxPrice;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return p => p.Price.Value >= _minPrice && p.Price.Value <= _maxPrice;
        }
    }
}
