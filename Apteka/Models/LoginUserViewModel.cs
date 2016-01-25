using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apteka.Models
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "Wpisz login, loginem może być twój email.")]
        [DataType(DataType.Text)]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Wpisz hasło.")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}