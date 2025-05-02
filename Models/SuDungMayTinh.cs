using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
namespace netmvc.Models
{
public class SuDungMayTinh
{
    public int ID{ get; set; }
    public int IDmaytinh{ get; set; }
    public int IDnguoidung { get; set; }
    public string? thoigian { get; set; }
    public DateTime Giobatdau { get; set; }
    public DateTime? Gioketthuc { get; set; }
}
}