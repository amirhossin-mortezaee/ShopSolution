using MediatR;

namespace Shop.Domain.Entities.ProductAgg.Events
{
    public record ProductActivatedEvent(Guid ProductId) : INotification;
}
