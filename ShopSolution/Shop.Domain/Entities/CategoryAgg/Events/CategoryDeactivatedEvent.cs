using MediatR;

namespace Shop.Domain.Entities.CategoryAgg.Events
{
    public record CategoryDeactivatedEvent(Guid CategoryId) : INotification;
}
