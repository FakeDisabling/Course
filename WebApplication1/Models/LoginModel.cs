using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не задано почта пользователя")]
        [Display(Name = "Логин")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
    }
}
