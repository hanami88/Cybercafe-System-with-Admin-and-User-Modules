using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
namespace netmvc.Models
{
public class TaiKhoan
{
    public int ID{ get; set; }
    [Required]
    public string Tendangnhap { get; set; }
    [Required]
    public string Hoten { get; set; }
    [Required]
    public string Matkhau { get; set; }
    [Required]
    [RegularExpression(@"^0\d{9}$", ErrorMessage = "Số điện thoại không hợp lệ")]
    public string SDT { get; set; }
    public int Quyen{get;set;}
    public string Sodu{get;set;}
}
}