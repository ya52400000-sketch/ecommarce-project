using ecommarce.BLL.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommarnce_api_CRUD_project.Controllers.Roles;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleServices _roleServices;

    public RoleController(IRoleServices roleServices)
    {
        _roleServices = roleServices;
    }

   
    [HttpPost("create")]
    public async Task<IActionResult> CreateRole([FromBody] string roleName)
    {
        var result = await _roleServices.CreateRoleAsync(roleName);

        if (!result.IsSucceded)
            return BadRequest(result);

        return Ok(result);
    }


    [HttpGet("all")]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _roleServices.GetAllRoleAsync();
        return Ok(roles);
    }


    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteRole([FromQuery] string roleName)
    {
        var result = await _roleServices.RemoveRoleAsync(roleName);

        if (!result.IsSucceded)
            return BadRequest(result);

        return Ok(result);
    }
}
