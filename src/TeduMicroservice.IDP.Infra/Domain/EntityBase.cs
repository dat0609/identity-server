
namespace TeduMicroservice.IDP.Infra.Domain;

public abstract class EntityBase<Key> : IEntityBase<Key>
{
    public Key Id { get; set; }
}