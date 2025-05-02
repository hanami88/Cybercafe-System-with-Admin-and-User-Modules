using Microsoft.EntityFrameworkCore;
using netmvc.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options){}
    public DbSet<TaiKhoan> TaiKhoan { get; set; }
    public DbSet<MayTinh> MayTinh { get; set; }
    public DbSet<SuDungMayTinh> SuDungMayTinh { get; set; }
}
