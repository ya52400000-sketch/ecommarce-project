using ecommarce.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.BLL.services;

public interface IRoleServices
{
    Task<CommenRespond> CreateRoleAsync(string RoleName);
    Task<CommenRespond> RemoveRoleAsync(string RoleName);
    Task<List<string>> GetAllRoleAsync( );
}
