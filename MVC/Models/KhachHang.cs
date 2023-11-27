using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MVC.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        [Required(ErrorMessage = "Mã khách hàng không được để trống.")]
        public string? IdKH { get; set; }
        [Required(ErrorMessage = "Họ và tên khách hàng không được để trống.")]
        public string? NameKH { get; set; }
        [Required(ErrorMessage = "Địa chỉ khách hàng không được để trống.")]
        public string? AddressKH { get; set; }
        [Required(ErrorMessage = "Số điện thoại khách hàng không được để trống.")]
        public string? PhoneKH { get; set; }

    }

}
