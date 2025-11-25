using MediatR;

namespace Shop.Domain.Entities.ProductAgg.Events
{
    public record ProductCategoryChangedEvent(
        Guid ProductId,
        Guid OldCategoryId,
        Guid NewCategoryId
    ) : INotification;
}
