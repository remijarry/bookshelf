using System.ComponentModel.DataAnnotations;

namespace Library.API.DTOs // overall the DTOs look good; it's good they don't directly reference any of your entities.
{
    public class UserForRegisterDto
    {
        [Required(ErrorMessage = "Username is required")] // use these throughout for DTOs that will be sent to server
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Password length must be between 4 and 8 characters")]
        public string Password { get; set; }
    }
}