using MediatR;
using Shop.Domain.Commons;
using Shop.Domain.Entities.ProductAgg.Events;
using Shop.Domain.Entities.ProductAgg.ValueObjects;

namespace Shop.Domain.Entities.ProductAgg
{
    public class Product : BaseEntity , IAggregateRoot
    {
        public ProductName Name { get; private set; }
        public ProductDescription Description { get; private set; }
        public ProductPrice Price { get; private set; }
        public int Stock { get; private set; }
        public Guid CategoryId { get; private set; }
        public bool IsActive { get; private set; }


        private readonly List<INotification> _events = new();
        public IReadOnlyList<INotification> DomainEvents => _events.AsReadOnly();
        //Constructor
        public Product(ProductName name , ProductDescription description , ProductPrice price,
            int stock, Guid categoryId)
        {
            if (stock < 0)
                throw new ArgumentException("موجودی نمی تواند مقدار منفی داشته باشد");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
            IsActive = true;

            //وقتی محصول ساخته میشود
            _events.Add(new ProductCreatedEvent(Id, Name.Value, Price.Value));
        }

        public void ChangeName(string newName)
        {
            var oldName = Name.Value;
            Name = ProductName.Create(newName);

            //رویداد تغییر نام
            _events.Add(new ProductNameChangedEvent(Id, oldName, newName));
        }

        public void ChangeDescription(string newDescription)
        {
            var oldDescription = Description.Value;
            Description = ProductDescription.Create(newDescription);

            _events.Add(new ProductDescriptionChangedEvent(Id, oldDescription, newDescription));
        }

        public void ChangePrice(decimal newAmount, string currency)
        {
            var oldPrice = Price.Value;
            Price = ProductPrice.Create(newAmount, currency);

            _events.Add(new ProductPriceChangedEvent(Id, oldPrice, newAmount));
        }

        public void IncreaseStock(int count)
        {
            if (count <= 0)
                throw new ArgumentException("مقدار افزایش موجودی باید بیشتر از صفر باشد");


            var oldStock = Stock;
            Stock += count;

            _events.Add(new ProductStockChangedEvent(Id, oldStock, Stock));
        }

        public void DecreaseStock(int count)
        {
            if (count <= 0)
                throw new ArgumentException("مقدار کاهش موجودی باید بیشتر از صفر باشد");

            if (Stock - count < 0)
                throw new InvalidOperationException("موجودی کافی نیست");

            var oldStock = Stock;
            Stock -= count;

            _events.Add(new ProductStockChangedEvent(Id, oldStock, Stock));
        }

        public void ChangeCategory(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
                throw new ArgumentException("شناسه دسته‌بندی معتبر نیست");


            var oldCategoryId = CategoryId;
            CategoryId = categoryId;

            _events.Add(new ProductCategoryChangedEvent(Id, oldCategoryId, categoryId));
        }

        public void Activate()
        {
            if (!IsActive)
            {
                IsActive = true;
                _events.Add(new ProductActivatedEvent(Id));
            }
        }

        public void Deactivate()
        {
            if (IsActive)
            {
                IsActive = false;
                _events.Add(new ProductDeactivatedEvent(Id));
            }
        }


        public void ClearEvents() => _events.Clear();
    }
}
