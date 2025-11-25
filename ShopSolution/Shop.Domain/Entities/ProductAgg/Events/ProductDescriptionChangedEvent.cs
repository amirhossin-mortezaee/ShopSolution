using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.ProductAgg.Events
{
    public record ProductDescriptionChangedEvent(
        Guid ProductId,
        string OldDescription,
        string NewDescription
    ) : INotification;
}
