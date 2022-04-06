using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication1.Models
{
    public class RegistrationModal
    {
        [Required]
        [Display(Name ="UserName")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
       [DataType(DataType.Password)]
        public string Password { get; set; }
     
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public bool AcceptUserAgreement { get; set; }
        public string RegistrationInValid { get; set; }

    }
}
