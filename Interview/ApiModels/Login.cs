using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Api.ApiModels
{
    public class Login
    {
        [Required]
        public string Username { get; set; }
        //Regex, Min 8 char, 1 digit, 1 special, 1 uppercase
        [Required]
        [RegularExpression(@"^(?!.* )(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Not a valid password")]    
        public string Password { get; set; }
    }
}
