using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTest.Shared.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email required!")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password required!")]
        public string password { get; set; }
    }
}
