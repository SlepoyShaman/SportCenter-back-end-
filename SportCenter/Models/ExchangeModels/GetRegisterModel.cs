using System.ComponentModel.DataAnnotations;

namespace SportCenter.Models.ExchangeModels
{
    public class GetRegisterModel
    {
        [Required(ErrorMessage = "Введите адресс электронной почты.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Придумайте пароль.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль.")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
}
