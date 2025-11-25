using MediatR;

namespace Shop.Domain.Entities.CategoryAgg.Events
{
    public record CategoryCreatedEvent(Guid CategoryId, string Name) : INotification;
}
