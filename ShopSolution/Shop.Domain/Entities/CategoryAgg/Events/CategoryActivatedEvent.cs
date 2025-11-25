using MediatR;

namespace Shop.Domain.Entities.CategoryAgg.Events
{
    public record CategoryActivatedEvent(Guid CategoryId) : INotification;
}
