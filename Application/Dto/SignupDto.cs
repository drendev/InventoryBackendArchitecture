using System.ComponentModel.DataAnnotations;


namespace Application.Dto
{
    public class SignupDto()
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required, Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        public string? Role { get; set; } = string.Empty;

        [Required]
        public DateTime Birthday { get; set; } = DateTime.Now;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
