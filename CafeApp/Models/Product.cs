using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace CafeApp.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Tên món không được để trống!")]
        [StringLength(100, ErrorMessage = "Tên món không được vượt quá 100 ký tự!")]
        public string? Name { get; set; }
        
        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập đường dẫn hình ảnh!")]
        public string? ImageSrc { get; set; }

        [BindProperty]
        public string? Details { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Giá sản phẩm không được để trống!")]
        [Range(1, 100000000, ErrorMessage = "Giá sản phẩm phải lớn hơn 0!")]
        public decimal? Price { get; set; }
    }
}
