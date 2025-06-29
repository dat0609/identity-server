using TeduMicroservice.IDP.Common.Domain;
using TeduMicroservice.IDP.Entities;

namespace TeduMicroservice.IDP.Common.Repositories;

public interface IPermissionRepository : IRepositoryBase<Permission, long>
{
    Task<IEnumerable<Permission>> GetPermissionByRole(string roleId, bool trackChange);
    Task UpdatePermissionByRoleId(string roleId, IEnumerable<Permission> permissions, bool trackChange);
}