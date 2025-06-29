using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using TeduMicroservice.IDP.Entities;

namespace TeduMicroservice.IDP.Common.Repositories;

public interface IRepositoryManager
{
    UserManager<User> UserManager { get; set; }
    RoleManager<IdentityRole> RoleManager { get; set; }
    IPermissionRepository Permission { get; }
    Task<int> SaveAsync();
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task EndTransactionAsync();
    Task RollbackTransactionAsync();
}