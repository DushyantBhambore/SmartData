using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Dto
{
    public class VerifyOTPDto
    {
        public string Email { get; set; }
        public string Otp { get; set; }
    }
}
