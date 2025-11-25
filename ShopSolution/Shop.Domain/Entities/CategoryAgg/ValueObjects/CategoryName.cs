using Shop.Domain.Commons;

namespace Shop.Domain.Entities.CategoryAgg.ValueObjects
{
    public class CategoryName : ValueObject
    {
        public string Value { get; set; }

        private CategoryName() { }

        public CategoryName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("نام دسته‌بندی نمی‌تواند خالی باشد.");

            if (value.Length < 3)
                throw new ArgumentException("نام دسته‌بندی باید حداقل 3 کاراکتر باشد.");

            if (value.Length > 100)
                throw new ArgumentException("نام دسته‌بندی نمی‌تواند بیش از 100 کاراکتر باشد.");

            Value = value;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
