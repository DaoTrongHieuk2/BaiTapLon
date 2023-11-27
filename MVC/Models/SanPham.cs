using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MVC.Models
{
    [Table("SanPham")]

    public class SanPham
    {
        [Key]
        [Required(ErrorMessage = "Mã sản phẩm không được để trống.")]
        public string? IdSP { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm sản phẩm không được để trống.")]
        public string? NameSP { get; set; }
        [Required(ErrorMessage = "Số lượng sản phẩm không được để trống.")]
        public string? NumberSP { get; set; }
        [Required(ErrorMessage = "Đơn giá sản phẩm không được để trống.")]
        public string? PriceSP { get; set; }
    }

}
