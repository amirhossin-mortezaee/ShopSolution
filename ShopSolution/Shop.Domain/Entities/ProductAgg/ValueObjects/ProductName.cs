using Shop.Domain.Commons;

namespace Shop.Domain.Entities.ProductAgg.ValueObjects
{
    public class ProductName : ValueObject
    {
        public string Value { get;}

        private ProductName() {}

        private ProductName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("نام محصول نمی تواند خالی باشد.");

            if (value.Length < 3)
                throw new ArgumentException("نام محصول باید حداقل سه کاراکتر باشد.");

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
