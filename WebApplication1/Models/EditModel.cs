using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EditModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPasswordConfirm { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
