using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
namespace netmvc.Models
{
public class MayTinh
{
    public int ID{ get; set; }
    public string Tenmay { get; set; }
    public string Trangthai { get; set; }
    public string dongia { get; set; }
    public string Doanhthu { get; set; }
}
}