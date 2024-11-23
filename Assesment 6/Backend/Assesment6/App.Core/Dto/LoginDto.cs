using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Dto
{
    public class LoginDto
    {
        public string Role { get; set; }
         public string Email { get; set; }
        public string Password { get; set; }
    }
}
