using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MVC.Models
{
    [Table("HoaDon")]

    public class HoaDon
    {
        [Key]
        [Required(ErrorMessage = "Mã hóa đơn không được để trống.")]
        public string? IdHD { get; set; }

        public string? IdKH { get; set; }
        public string? IdNV { get; set; }
        public string? IdSP { get; set; }
        public int MyProperty { get; set; }

        [ForeignKey("IdKH")]
        public KhachHang? KhachHang { get; set; }

        [ForeignKey("IdNV")]
        public NhanVien? NhanVien { get; set; }

        [ForeignKey("IdSP")]
        public SanPham? SanPham { get; set; }
    }

}
