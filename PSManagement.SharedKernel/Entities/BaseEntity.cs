using PSManagement.SharedKernel.Events;
using System.Collections.Generic;

namespace PSManagement.SharedKernel.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
        public static bool operator ==(BaseEntity first, BaseEntity second)
        {
            if (first is null && second is null)
            {
                return true;
            }

            if (first is null || second is null)
            {
                return false;
            }

            return first.Equals(second);
        }

        public static bool operator !=(BaseEntity first, BaseEntity second)
        {
            return !(first == second);
        }

        public bool Equals(BaseEntity other)
        {
            if (other is null || other.GetType() != GetType())
            {
                return false;
            }

            return other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            // Check if the two have same type.
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            // Check If the obj if of type Entity.
            if (obj is not BaseEntity entity)
            {
                return false;
            }

            return entity.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }
}
