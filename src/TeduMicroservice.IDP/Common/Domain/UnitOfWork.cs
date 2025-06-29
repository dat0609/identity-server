using TeduMicroservice.IDP.Context;

namespace TeduMicroservice.IDP.Common.Domain;

public class UnitOfWork : IUnitOfWork
{
    private readonly TeduIdentityContext _context;

    public UnitOfWork(TeduIdentityContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public Task<int> CommitAsync()
    {
        return _context.SaveChangesAsync();
    }
}