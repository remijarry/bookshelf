using System.ComponentModel.DataAnnotations;

namespace Library.API.DTOs
{
    public class UserForRegisterDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Password length must be between 4 and 8 characters")]
        public string Password { get; set; }
    }
}