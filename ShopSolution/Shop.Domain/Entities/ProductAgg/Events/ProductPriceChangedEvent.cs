using MediatR;

namespace Shop.Domain.Entities.ProductAgg.Events
{
    public record ProductPriceChangedEvent(Guid ProductId, decimal OldPrice, decimal NewPrice) : INotification;
}
