using Shop.Domain.Commons;

namespace Shop.Domain.Entities.ProductAgg.ValueObjects
{
    public class ProductName : ValueObject
    {
        public string Value { get; private set; }  // non-nullable

        private ProductName() { }  // برای EF Core

        private ProductName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("نام محصول نمی‌تواند خالی باشد");

            if (value.Length < 3)
                throw new ArgumentException("نام محصول باید حداقل ۳ کاراکتر باشد");

            Value = value;
        }

        public static ProductName Create(string value)
        {
            return new ProductName(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
