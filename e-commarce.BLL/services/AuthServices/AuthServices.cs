using ecommarce.BLL.DTOs;
using ecommarce.BLL.Handler;
using ecommarce.DAL.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ecommarce.BLL.services;

public class AuthServices : IAuthServices
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    public AuthServices(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    public async Task<CommenRespond> LoginAsync(LoginDto loginDto)
    {
      var existingemail= await _userManager.FindByEmailAsync(loginDto.Email);
        if (existingemail == null) 
        {
            return new CommenRespond("email or password is not valid",false);
        }
        var checkpassword= await _userManager.CheckPasswordAsync(existingemail, loginDto.Password);
        if (!checkpassword)
        {
            return new CommenRespond("email or password is not valid", false);
        }
        var token = await TokenHandler.CreateTokenAsync(existingemail, _configuration,_userManager);
        return  new CommenRespond("login succeed", true,token);
        
    }

    public async Task<CommenRespond> RegisterAsync(RegisterDto dto)
    {
       var existingEmail= await _userManager.FindByEmailAsync(dto.Email);
        if(existingEmail != null) 
        {
            return new CommenRespond("email already existed", false);
        } 
        var User = new AppUser
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            UserName = dto.Email

        };
        var resulte = await _userManager.CreateAsync(User, dto.Password);
        if (!resulte.Succeeded)
        {
            var Errors = resulte.Errors.Select(e => e.Description).ToList();
            return new CommenRespond("the account didnt create", false,null,Errors);
        }
        var Roleresulte = await _userManager.AddToRoleAsync(User, "User");
        if (!Roleresulte.Succeeded)
        {
            var error = Roleresulte.Errors.Select(e => e.Description).ToList();
            return new CommenRespond("cant assinge this role", false,null,error);
        }
    
        return new CommenRespond("the account has been created",true);
     
    }
}
