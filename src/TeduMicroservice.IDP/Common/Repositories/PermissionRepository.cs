using TeduMicroservice.IDP.Common.Domain;
using TeduMicroservice.IDP.Context;
using TeduMicroservice.IDP.Entities;

namespace TeduMicroservice.IDP.Common.Repositories;

public class PermissionRepository : RepositoryBase<Permission, long>, IPermissionRepository
{
    public PermissionRepository(TeduIdentityContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
    {
    }

    public Task<IEnumerable<Permission>> GetPermissionByRole(string roleId, bool trackChange)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePermissionByRoleId(string roleId, IEnumerable<Permission> permissions, bool trackChange)
    {
        throw new NotImplementedException();
    }
}