using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class RegisterDTO
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", 
        ErrorMessage = "Password must have 1 uppercase, 1 Lowercase, 1 number, 1 non alphanumeric and at least 6 characters")] // one uppercase one lowercase one alphanumeric letter
        public string Password { get; set; }

    }
}