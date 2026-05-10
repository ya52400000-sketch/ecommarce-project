using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommarce.BLL.DTOs;

public class CommenRespond
{
    public string Massege { get; set; } = string.Empty;
    public bool IsSucceded { get; set; }
    public object Addtionalinfo { get; set; }
    public List<string> Error { get; set; }

    public CommenRespond(string massege,bool issucceded,string addtionalinfo=null,List<string> error=null)
    {
        Massege = massege;
        IsSucceded = issucceded;
        Addtionalinfo = addtionalinfo;
        Error = error;
    }
    
}
