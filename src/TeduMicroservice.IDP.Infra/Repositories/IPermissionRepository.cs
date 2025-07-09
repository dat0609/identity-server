using TeduMicroservice.IDP.Infra.Domain;
using TeduMicroservice.IDP.Infra.Entities;

namespace TeduMicroservice.IDP.Infra.Repositories;

public interface IPermissionRepository : IRepositoryBase<Permission, long>
{
    Task<IReadOnlyList<Permission>> GetPermissionByRole(string roleId);
    Task UpdatePermissionByRoleId(string roleId, IEnumerable<Permission> permissions, bool trackChange);
}