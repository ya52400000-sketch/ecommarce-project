using ecommarce.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.BLL.services;

public interface IAuthServices
{
    Task<CommenRespond> RegisterAsync(RegisterDto dto);
    Task<CommenRespond> LoginAsync(LoginDto loginDto);
}
