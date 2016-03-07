using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniBookStore.Areas.Admin.Models.Dto
{
    public class AdminRegisterDto
    {
        [Required(ErrorMessage = "Ad soyad alani bos gecilemez")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email alani bos gecilemez")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Kullanici adi alani bos gecilemez")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Sifre adi alani bos gecilemez")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Sifre tekrar adi alani bos gecilemez"), Compare("Password", ErrorMessage = "Sifreler eslestirilemiyor")]
        public string ConfirmPassword { get; set; }

        public bool isActive { get; set; }
    }
}