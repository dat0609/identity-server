namespace TeduMicroservice.IDP.Infra.Domain;

public interface IUnitOfWork : IDisposable
{
    Task<int> CommitAsync();
}