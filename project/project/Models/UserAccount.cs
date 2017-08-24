using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage ="Введите имя ,пожалуйста .")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите фамилию ,пожалуйста .")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Введите е-мейл ,пожалуйста .")]
        [EmailAddress(ErrorMessage = "Please enter a vaild email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите ник ,пожалуйста .")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Введите пароль ,пожалуйста .")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Пожалуйста,потдвердите пароль")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
         
    }
}