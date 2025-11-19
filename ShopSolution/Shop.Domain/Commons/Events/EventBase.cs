using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Commons.Events
{
    public abstract class EventBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime OccurredOn { get; set; } = DateTime.UtcNow;

        public Guid? EntityId { get; set; }

        protected EventBase() { }

        protected EventBase(Guid? entityId)
        {
            EntityId = entityId;
        }
    }
}
