namespace TeduMicroservice.IDP.Common.Domain;

public abstract class EntityBase<Key> : IEntityBase<Key>
{
    public Key Id { get; set; }
}