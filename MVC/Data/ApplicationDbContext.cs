using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
        public class ApplicationDbContext : DbContext
        {
                public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
                { }
                public DbSet<KhachHang> KhachHang { get; set; }
                public DbSet<NhanVien> NhanVien { get; set; }

                public DbSet<HoaDon> HoaDon { get; set; }

                public DbSet<SanPham> SanPham { get; set; }

        }
}