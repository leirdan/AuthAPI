using System.ComponentModel.DataAnnotations;

namespace AuthAPI.Data.DTO
{
    public class CreateUserDTO
    {
        [Required] 
        public string Username { get; set;}
        [Required]
        public string Email { get; set;}
        [Required]
        [DataType(DataType.Password)]
        private string Password { get; set;}
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime Birthday { get; set; }
    }
}
