using System.ComponentModel.DataAnnotations;

namespace Task1.Models.DTOs
{
    public class AuthenticationModel
    {
        [Required(ErrorMessage ="Username is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
