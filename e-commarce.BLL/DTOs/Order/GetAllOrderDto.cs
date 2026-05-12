using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commarce.BLL.DTOs;

public class GetAllOrdersDto
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalPrice { get; set; }
 
}