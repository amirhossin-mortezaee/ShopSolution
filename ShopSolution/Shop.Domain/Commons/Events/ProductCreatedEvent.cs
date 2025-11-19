using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Commons.Events
{
    public class ProductCreatedEvent : EventBase
    {
        public string ProductName { get; private set; }

        public ProductCreatedEvent(Guid productId, string productName)
            : base(productId)
        {
            ProductName = productName;
        }
    }
}
