using Shop.Domain.Commons;

namespace Shop.Domain.Entities.ProductAgg.ValueObjects
{
    public class ProductDescription : ValueObject
    {
        public string Value { get; private set; }

        private ProductDescription() { }

        private ProductDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("توضیحات محصول نمی‌تواند خالی باشد");

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
