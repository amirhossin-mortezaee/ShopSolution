using MediatR;

namespace Shop.Domain.Entities.ProductAgg.Events
{
    public record ProductDeactivatedEvent(Guid ProductId) : INotification;
}
