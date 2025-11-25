using Shop.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.CategoryAgg.ValueObjects
{
    public class CategoryDescription : ValueObject
    {
        public string Value { get; set; }

        private CategoryDescription() { } // برای EF Core

        public CategoryDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("توضیحات دسته‌بندی نمی‌تواند خالی باشد.");

            if (value.Length > 500)
                throw new ArgumentException("توضیحات دسته‌بندی نمی‌تواند بیش از 500 کاراکتر باشد.");

            Value = value;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
