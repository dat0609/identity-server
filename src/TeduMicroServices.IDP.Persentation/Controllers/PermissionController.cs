using Microsoft.AspNetCore.Mvc;
using TeduMicroservice.IDP.Common.Repositories;

namespace TeduMicroServices.IDP.Presentation.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PermissionController : ControllerBase
{
    private readonly IRepositoryManager _repositoryManager;
    
    public PermissionController(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetPermission(string roleId)
    {
        var result = await _repositoryManager.Permission.GetPermissionByRole(roleId);
        return Ok(result);
    }
}