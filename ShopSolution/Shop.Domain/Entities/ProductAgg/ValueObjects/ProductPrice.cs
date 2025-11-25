using Shop.Domain.Commons;

namespace Shop.Domain.Entities.ProductAgg.ValueObjects
{
    public class ProductPrice : ValueObject
    {
        public decimal Value { get; private set; }
        public string Currency { get; private set; }  // non-nullable

        private ProductPrice() { }

        private ProductPrice(decimal value, string currency = "IRR")
        {
            if (value < 0)
                throw new ArgumentException("قیمت محصول نمی‌تواند منفی باشد");

            Value = value;
            Currency = string.IsNullOrWhiteSpace(currency) ? "IRR" : currency;
        }

        public static ProductPrice Create(decimal value, string currency = "IRR")
        {
            return new ProductPrice(value, currency);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Currency;
        }
    }
}
