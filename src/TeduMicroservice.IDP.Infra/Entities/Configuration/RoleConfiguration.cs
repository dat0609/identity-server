using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeduMicroservice.IDP.Infra.Entities.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(new IdentityRole
                 {
                     Name = "Admin",
                     Id = Guid.NewGuid().ToString(),
                     NormalizedName = "ADMIN"
                 },
                 new IdentityRole
                 {
                     Name = "Customer",
                     Id = Guid.NewGuid().ToString(),
                     NormalizedName = "CUSTOMER"
                 });
    }
}