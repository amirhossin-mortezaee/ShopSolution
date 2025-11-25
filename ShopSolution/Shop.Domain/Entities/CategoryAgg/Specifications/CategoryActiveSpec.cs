using Shop.Domain.Commons;
using System.Linq.Expressions;

namespace Shop.Domain.Entities.CategoryAgg.Specifications
{
    public class CategoryActiveSpec : Specification<Category>
    {
        public override Expression<Func<Category, bool>> ToExpression()
        {
            return c => c.IsActive;
        }
    }
}
