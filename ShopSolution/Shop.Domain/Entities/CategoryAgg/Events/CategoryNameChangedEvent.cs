using MediatR;

namespace Shop.Domain.Entities.CategoryAgg.Events
{
    public record CategoryDescriptionChangedEvent(Guid CategoryId, string OldDescription, string NewDescription) : INotification;
}
