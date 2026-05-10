using ecommarce.DAL.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.BLL.Handler;

public class TokenHandler
{
    public static async Task<string> CreateTokenAsync(AppUser user, IConfiguration config,UserManager<AppUser> userManager)
    {
        var clamis = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id),
            new Claim(ClaimTypes.Email,user.Email)
        };
        var userRole= await userManager.GetRolesAsync(user);
        foreach (var role in userRole) 
        {
            clamis.Add(new Claim(ClaimTypes.Role, role));
        }

        var keybytes = Encoding.UTF8.GetBytes(config["JWT:Key"]);
        var key = new SymmetricSecurityKey(keybytes);

        var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken
            (
            issuer: config["JWT:Issuer"],
            audience: config["JWT:Audience"],
            expires: DateTime.UtcNow.AddDays(Convert.ToDouble(config["JWT:DurationInDays"])),
            claims: clamis,
          signingCredentials: creds

            );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
