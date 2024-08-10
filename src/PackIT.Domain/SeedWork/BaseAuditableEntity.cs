namespace PackIT.Domain.SeedWork
{
    public abstract class BaseAuditableEntity<T> : BaseEntity<T>
    {
        public DateTimeOffset Created { get; private set; }

        public string? CreatedBy { get; private set; }

        public DateTimeOffset LastModified { get; private set; }

        public string? LastModifiedBy { get; private set; }
    }
}
