using MediatR;

namespace Shop.Domain.Entities.CategoryAgg.Events
{
    public record CategoryParentChangedEvent(Guid CategoryId, Guid? OldParentId, Guid? NewParentId) : INotification;
}
