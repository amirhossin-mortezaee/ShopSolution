namespace Shop.Domain.Commons
{
    /// <summary>
    /// Marker interface to indicate that an Entity is an Aggregate Root.
    /// Aggregate Root is the main entity of a group of related entities
    /// that should be accessed only through this root.
    /// </summary>
    public interface IAggregateRoot
    {
        // Marker interface: no members required
    }
}
