using Dapper;
using TeduMicroservice.IDP.Infra.Domain;
using TeduMicroservice.IDP.Infra.Entities;

namespace TeduMicroservice.IDP.Infra.Repositories;

public class PermissionRepository : RepositoryBase<Permission, long>, IPermissionRepository
{
    public PermissionRepository(TeduIdentityContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
    {
    }

    public async Task<IReadOnlyList<Permission>> GetPermissionByRole(string roleId)
    {
        var parammeters = new DynamicParameters();
        parammeters.Add("@roleId", roleId);
        var result = await QueryAsync("Get_Permissions_ByRoleId", parammeters);
        return result;
    }

    public Task UpdatePermissionByRoleId(string roleId, IEnumerable<Permission> permissions, bool trackChange)
    {
        throw new NotImplementedException();
    }
}