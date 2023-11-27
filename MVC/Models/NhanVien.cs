using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MVC.Models
{
    [Table("NhanVien")]

    public class NhanVien
    {
        [Key]
        [Required(ErrorMessage = "Mã nhân viên không được để trống.")]
        public string? IdNV { get; set; }
        [Required(ErrorMessage = "Họ và tên nhân viên không được để trống.")]
        public string? NameNV { get; set; }
        [Required(ErrorMessage = "Địa chỉ nhân viên không được để trống.")]
        public string? AddressNV { get; set; }
        [Required(ErrorMessage = "Số điện thoại nhân viên không được để trống.")]
        public string? PhoneNV { get; set; }
        [Required(ErrorMessage = "Tuổi nhân viên không được để trống.")]
        public string? AgeNV { get; set; }
    }

}
