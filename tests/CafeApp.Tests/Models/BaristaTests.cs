using System.ComponentModel.DataAnnotations;
using CafeApp.Models;
using WebProject.Models; // Lưu ý: Barista.cs đang dùng namespace WebProject (lỗi tồn dưng của repo gốc, xem issue #20)

namespace CafeApp.Tests.Models
{
    /// <summary>
    /// Issue #13 [C4] — Unit test bổ sung cho model Barista.
    /// Kiểm tra trạng thái mặc định và các attribute validation ([Required], [EmailAddress]).
    /// </summary>
    public class BaristaTests
    {
        private static List<ValidationResult> Validate(object model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            Validator.TryValidateObject(model, context, results, validateAllProperties: true);
            return results;
        }

        [Fact]
        public void NewBarista_IsAuthenticated_IsFalse()
        {
            // Arrange + Act
            var barista = new Barista();

            // Assert — constructor mặc định gán IsAuthenticated = false
            Assert.False(barista.IsAuthenticated);
        }

        [Fact]
        public void Barista_MissingEmail_MissingPassword_ValidationFails()
        {
            // Arrange — model rỗng, cả Email lẫn Password đều violate [Required]
            var barista = new Barista
            {
                Email = null,
                Password = null
            };

            // Act
            var errors = Validate(barista);

            // Assert
            Assert.True(errors.Count >= 2);
        }

        [Fact]
        public void Barista_InvalidEmail_ValidationFails()
        {
            var barista = new Barista
            {
                Email = "không-phải-email",
                Password = "admin"
            };

            var errors = Validate(barista);

            // [EmailAddress] từ chối chuỗi không đúng định dạng
            Assert.Contains(errors, e => e.MemberNames.Contains("Email"));
        }

        [Fact]
        public void Barista_ValidEmailAndPassword_ValidationPasses()
        {
            var barista = new Barista
            {
                Email = "admin@gmail.com",
                Password = "admin"
            };

            var errors = Validate(barista);

            Assert.Empty(errors);
        }

        [Fact]
        public void Barista_EmailAndPassword_RoundTrips()
        {
            var barista = new Barista
            {
                Email = "test@gmail.com",
                Password = "123"
            };

            Assert.Equal("test@gmail.com", barista.Email);
            Assert.Equal("123", barista.Password);
        }
    }
}
