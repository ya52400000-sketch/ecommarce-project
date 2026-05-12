using ecommarce.BLL.DTOs;
using ecommarce.BLL.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommarnce_api_CRUD_project.Controllers.Register;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthServices _authService;

    public AuthController(IAuthServices authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var result = await _authService.RegisterAsync(dto);

        if (!result.IsSucceded)
            return BadRequest(result);

        return Ok(result);
    }
}
