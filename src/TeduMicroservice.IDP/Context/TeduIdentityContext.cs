using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeduMicroservice.IDP.Entities;

namespace TeduMicroservice.IDP.Context;

public class TeduIdentityContext : IdentityDbContext<User>
{
    public TeduIdentityContext(DbContextOptions<TeduIdentityContext> options) : base(options)
    {
        
    }

    public DbSet<Permission> Permissions { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(TeduIdentityContext).Assembly);
        base.OnModelCreating(builder);
    }
}