namespace TeduMicroservice.IDP.Infra.Domain;

public interface IEntityBase<T>
{
    T Id { get; set; }
}