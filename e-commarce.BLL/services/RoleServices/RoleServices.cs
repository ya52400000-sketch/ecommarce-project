using ecommarce.BLL.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.BLL.services;

public class RoleService : IRoleServices
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<CommenRespond> CreateRoleAsync(string roleName)
    {
        var exists = await _roleManager.RoleExistsAsync(roleName);
        if (exists)
        {
            return new CommenRespond("role already exists", false);
        }

        var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

        if (!result.Succeeded)
        {
            return new CommenRespond("role creation failed", false);
        }

        return new CommenRespond("role created successfully", true);
    }

    public async Task<List<string>> GetAllRoleAsync()
    {
        return await _roleManager.Roles
            .Select(r => r.Name ?? "")
            .ToListAsync();
    }

    public async Task<CommenRespond> RemoveRoleAsync(string roleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);

        if (role == null)
        {
            return new CommenRespond("role not found", false);
        }

        var result = await _roleManager.DeleteAsync(role);

        if (!result.Succeeded)
        {
            return new CommenRespond("role deletion failed", false);
        }

        return new CommenRespond("role deleted successfully", true);
    }
}