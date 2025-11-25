using MediatR;

namespace Shop.Domain.Entities.ProductAgg.Events
{
    public record ProductNameChangedEvent(Guid ProductId, string OldName, string NewName) : INotification;
}
