using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apteka.Models
{
    public class RegisterUserViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Hasło musi mieć co najnmniej 8 znaków")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Hasła muszą się zgadzać")]
        [MinLength(8, ErrorMessage = "Hasło musi mieć co najmniej 8 znaków")]
        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        public string ConfirmationPassword { get; set; }

        [RegularExpression(@"\d{10}", ErrorMessage = "Wpisany numer NIP jest niepoprawny")]
        public string NIP { get; set; }

        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [RegularExpression(@"\d{2}-\d{3}", ErrorMessage = "Wpisany kod pocztowy jest niepoprawny")]
        [Display(Name = "Kod pocztowy")]
        public string ZipCode { get; set; }

        [Display(Name = "Numer mieszkania")]
        public string ApartmentNumber { get; set; }

        [Display(Name = "Numer domu")]
        public string HouseNumber { get; set; }
    }
}