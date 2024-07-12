using PSManagement.SharedKernel.Entities;

namespace PSManagement.SharedKernel.Aggregate
{
    // Apply this marker interface only to aggregate root entities
    // Repositories will only work with aggregate roots, not their children
    public class IAggregateRoot : BaseEntity
    {
    }
}
