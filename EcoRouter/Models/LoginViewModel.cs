using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcoRouter.Models
{
    public class LoginViewModel
    {
        public string LoginErrorMessage { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "This field is required.")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }
    }
}
