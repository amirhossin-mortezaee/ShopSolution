using OnlineShop.Domain.Commons;
using Shop.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.ProductAgg
{
    public class Product : BaseEntity , IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public Guid CategoryId { get; private set; }
        public bool IsActive { get; private set; }
    }
}
