using Shop.Domain.Commons;
using System.Linq.Expressions;

namespace Shop.Domain.Entities.ProductAgg.Specifications
{
    public class ProductByNameSpec : Specification<Product>
    {
        private readonly string _name;

        public ProductByNameSpec(string name)
        {
            _name = name;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return p => p.Name.Value.Contains(_name);
        }
    }
}
