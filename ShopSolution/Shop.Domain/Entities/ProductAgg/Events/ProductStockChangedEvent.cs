using MediatR;

namespace Shop.Domain.Entities.ProductAgg.Events
{
    public record ProductStockChangedEvent(Guid ProductId, int OldStock, int NewStock) : INotification;
}
