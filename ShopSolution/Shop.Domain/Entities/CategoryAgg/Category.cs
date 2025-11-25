using MediatR;
using Shop.Domain.Commons;
using Shop.Domain.Entities.CategoryAgg.Events;
using Shop.Domain.Entities.CategoryAgg.ValueObjects;

namespace Shop.Domain.Entities.CategoryAgg
{
    public class Category : BaseEntity , IAggregateRoot
    {
        // ---------- Properties ----------
        public CategoryName Name { get; private set; }
        public CategoryDescription Description { get; private set; }
        public Guid? ParentId { get; set; }
        public bool IsActive { get; set; }

        private readonly List<INotification> _events = new();
        public IReadOnlyList<INotification> DomainEvents => _events.AsReadOnly();

        // ---------- Constructors ----------
        private Category() { }

        public Category(CategoryName name, CategoryDescription description, Guid? parentId = null )
        {
            Name = name;
            Description = description;
            ParentId = parentId;
            IsActive = true;


            _events.Add(new CategoryCreatedEvent(Id, Name.Value));
        }

        // ---------- Behavior Methods ----------
        public void ChangeName(string newName)
        {
            if (string.Equals(Name.Value, newName, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("نام دسته‌بندی مشابه نام قبلی است.");

            var oldName = Name.Value;
            Name = new CategoryName(newName);

            _events.Add(new CategoryDescriptionChangedEvent(Id, oldName, newName));
        }

        public void ChangeDescription(string newDescription)
        {
            var oldDescription = Description.Value;
            Description = new CategoryDescription(newDescription);

            _events.Add(new CategoryDescriptionChangedEvent(Id, oldDescription, newDescription));
        }

        public void ChangeParent(Guid? newParentId)
        {
            var oldParentId = ParentId;
            ParentId = newParentId;

            _events.Add(new CategoryParentChangedEvent(Id, oldParentId, newParentId));
        }

        public void Activate()
        {
            if (!IsActive)
            {
                IsActive = true;
                _events.Add(new CategoryActivatedEvent(Id));
            }
        }

        public void Deactivate()
        {
            if (IsActive)
            {
                IsActive = false;
                _events.Add(new CategoryDeactivatedEvent(Id));
            }
        }

        public void ClearEvents() => _events.Clear();
    }
}
