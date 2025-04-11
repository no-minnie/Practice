using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Models 
{
    public class ContactViewModel
    {

        [Required(ErrorMessage = "Требуется Имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Требуется Номер телефона")] 
        [Phone(ErrorMessage = "Неверный формат телефона")]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Требуется Email")] 
        [EmailAddress(ErrorMessage = "Неверный формат Email")]
        [Display(Name = "Email")]
        public string Email { get; set; } 
    }
}