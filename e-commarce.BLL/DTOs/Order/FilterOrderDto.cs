using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.BLL.DTOs;

public class FilterOrderDto
{
    public string? Status { get; set; }
    public string? UserId { get; set; }

    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
}
