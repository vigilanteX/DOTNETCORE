using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Please Check The Password")]
        public string ConfirmPassword { get; set; }

    }
}
