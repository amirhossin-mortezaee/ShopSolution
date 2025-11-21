using Shop.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.ProductAgg.ValueObjects
{
    public class ProductDescription : ValueObject
    {
        public string Value { get;}

        private ProductDescription() { }

        private ProductDescription(string value)
        {
            if (value?.Length > 500)
                throw new ArgumentException("توضیحات نمی تواند بیشتر از 500 کاراکتر باشد");
            Value = value;
        }

        public static ProductDescription Create(string value) 
        {
            return new ProductDescription(value); 
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
