using Shop.Domain.Commons;
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

        // ---------- Constructors ----------
        private Category() { }

        public Category(CategoryName name, CategoryDescription description, Guid? parentId = null )
        {
            Name = name;
            Description = description;
            ParentId = parentId;
            IsActive = true;
            
            //ایونت دامنه
            //Todo:
        }

        // ---------- Behavior Methods ----------
        public void ChangeName(string newName)
        {
            if (string.Equals(Name.Value, newName, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("نام دسته‌بندی مشابه نام قبلی است.");

            Name = new CategoryName(newName);
        }

        public void ChangeDescription(string newDescription)
        {
            Description = new CategoryDescription(newDescription);
        }

        public void ChangeParent(Guid? newParentId)
        {
            ParentId = newParentId;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
