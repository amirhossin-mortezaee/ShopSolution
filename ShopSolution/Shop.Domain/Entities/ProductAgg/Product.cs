using Shop.Domain.Commons;
using Shop.Domain.Entities.ProductAgg.ValueObjects;

namespace Shop.Domain.Entities.ProductAgg
{
    public class Product : BaseEntity , IAggregateRoot
    {
        public ProductName Name { get; private set; }
        public ProductDescription Description { get; private set; }
        public Money Price { get; private set; }
        public int Stock { get; private set; }
        public Guid CategoryId { get; private set; }
        public bool IsActive { get; private set; }
    }
}
