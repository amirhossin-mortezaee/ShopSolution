using Shop.Domain.Commons;
using System.Linq.Expressions;

namespace Shop.Domain.Entities.ProductAgg.Specifications
{
    public class ProductInCategorySpec : Specification<Product>
    {
        private readonly Guid _categoryId;

        public ProductInCategorySpec(Guid categoryId) => _categoryId = categoryId;

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return p => p.CategoryId == _categoryId;
        }
    }
}
