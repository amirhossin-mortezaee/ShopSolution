using Shop.Domain.Commons;
using System.Linq.Expressions;

namespace Shop.Domain.Entities.CategoryAgg.Specifications
{
    public class CategoryByParentSpec : Specification<Category>
    {
        private readonly Guid? _parentId;

        public CategoryByParentSpec(Guid? parentId) => _parentId = parentId;

        public override Expression<Func<Category, bool>> ToExpression()
        {
            return c => c.ParentId == _parentId;
        }
    }
}
