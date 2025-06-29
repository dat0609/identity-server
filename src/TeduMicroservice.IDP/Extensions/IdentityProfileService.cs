using System.Security.Claims;
using Duende.IdentityModel;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using TeduMicroservice.IDP.Entities;

namespace TeduMicroservice.IDP.Extensions;

public class IdentityProfileService : IProfileService
{
    private readonly IUserClaimsPrincipalFactory<User> _claimsPrincipal;
    private readonly UserManager<User> _userManager;

    public IdentityProfileService(IUserClaimsPrincipalFactory<User> claimsPrincipal, UserManager<User> userManager)
    {
        _claimsPrincipal = claimsPrincipal;
        _userManager = userManager;
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var sub = context.Subject.GetSubjectId();
        var user = await _userManager.FindByIdAsync(sub)
                    ?? throw new ArgumentNullException("User not found");

        var principal = await _claimsPrincipal.CreateAsync(user);
        var claims = principal.Claims.ToList();
        var roles = await _userManager.GetRolesAsync(user);
        
        claims.Add(new Claim(JwtClaimTypes.Name, user.FirstName));
        //...

        context.IssuedClaims = claims;
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        var sub = context.Subject.GetSubjectId();
        var user = await _userManager.FindByIdAsync(sub)
                   ?? throw new ArgumentNullException("User not found");

        context.IsActive = user != null;
    }
}