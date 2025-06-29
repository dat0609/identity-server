using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using TeduMicroservice.IDP.Common.Domain;
using TeduMicroservice.IDP.Context;
using TeduMicroservice.IDP.Entities;

namespace TeduMicroservice.IDP.Common.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly TeduIdentityContext _context;
    private readonly Lazy<IPermissionRepository> _permissionRepository;

    public RepositoryManager(IUnitOfWork unitOfWork, TeduIdentityContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _unitOfWork = unitOfWork;
        _context = context;
        _permissionRepository = new Lazy<IPermissionRepository>(() => new PermissionRepository(_context, _unitOfWork));
        UserManager = userManager;
        RoleManager = roleManager;
    }

    public UserManager<User> UserManager { get; set; }
    public RoleManager<IdentityRole> RoleManager { get; set; }
    public IPermissionRepository Permission => _permissionRepository.Value;

    public Task<int> SaveAsync()
    {
        return _unitOfWork.CommitAsync();
    }

    public Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return _context.Database.BeginTransactionAsync();
    }

    public Task EndTransactionAsync()
    {
        return _context.Database.CommitTransactionAsync();
    }

    public Task RollbackTransactionAsync()
    {
        return _context.Database.RollbackTransactionAsync();
    }
}