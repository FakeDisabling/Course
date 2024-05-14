using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CardViewModel
    {
        [Required(ErrorMessage = "Поле \"Номер карты\" обязательно для заполнения.")]
        [CreditCard(ErrorMessage = "Введите действительный номер кредитной карты.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Поле \"Имя\" обязательно для заполнения.")]
        [StringLength(17, ErrorMessage = "Имя не может быть длиннее 17 символов.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле \"Фамилия\" обязательно для заполнения.")]
        [StringLength(25, ErrorMessage = "Фамилия не может быть длиннее 25 символов.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле \"Адрес выставления счета\" обязательно для заполнения.")]
        public string BillingAddress { get; set; }

        [Required(ErrorMessage = "Поле \"Город\" обязательно для заполнения.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Поле \"Почтовый индекс\" обязательно для заполнения.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Поле \"Страна\" обязательно для заполнения.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Поле \"Телефон\" обязательно для заполнения.")]
        [Phone(ErrorMessage = "Введите действительный номер телефона.")]
        public string Phone { get; set; }
    }
}
