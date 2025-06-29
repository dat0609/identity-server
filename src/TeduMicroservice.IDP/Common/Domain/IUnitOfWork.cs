namespace TeduMicroservice.IDP.Common.Domain;

public interface IUnitOfWork : IDisposable
{
    Task<int> CommitAsync();
}