using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Models
{
    public class Barista
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BaristaId { get; set; }

        [Required(ErrorMessage = "Địa chỉ email không được để trống!")]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ (ví dụ: name@example.com)!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [MinLength(3, ErrorMessage = "Mật khẩu phải có ít nhất 3 ký tự!")]
        public string? Password { get; set; }

        public bool IsAuthenticated { get; set; }

        public Barista()
        {
            IsAuthenticated = false;
        }
    }
}
