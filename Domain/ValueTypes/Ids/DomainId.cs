namespace Domain.ValueTypes.Ids
{
    public class DomainId
    {
        public DomainId(string id)
        {
            Id = id;
        }
        public string Id { get; }

        protected bool Equals(DomainId other)
        {
            return string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DomainId) obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }

        public static bool operator ==(DomainId a, DomainId b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            return a.Id == b.Id;
        }

        public static bool operator !=(DomainId a, DomainId b)
        {
            if (ReferenceEquals(a, b))
            {
                return false;
            }

            if ((object)a == null || (object)b == null)
            {
                return true;
            }

            return a.Id != b.Id;
        }

    }
}