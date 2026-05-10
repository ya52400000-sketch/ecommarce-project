using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.BLL.DTOs;

public class LoginDto
{
    [Required]
    [EmailAddress(ErrorMessage ="please enter valid Email")]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}
