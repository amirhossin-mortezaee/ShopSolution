using MediatR;
namespace Shop.Domain.Entities.ProductAgg.Events
{
    public record ProductCreatedEvent(Guid ProductId, string Name, decimal Price) : INotification;
}
