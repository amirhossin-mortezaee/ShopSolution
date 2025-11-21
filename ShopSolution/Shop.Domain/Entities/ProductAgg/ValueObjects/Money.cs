using Shop.Domain.Commons;

namespace Shop.Domain.Entities.ProductAgg.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Amount { get;}
        public string Currency { get; }

        private Money() { }

        public Money(decimal amount , string currency)
        {
            if(amount < 0)
                throw new ArgumentException("مقدار وارد شده نمی تواند منفی باشد");
            
            Amount = amount;
            Currency = currency;
        }

        public static Money Create(decimal amount , string currency)
        {
            return new Money(amount, currency);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
