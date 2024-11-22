using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Dto
{
    public class CountryDto
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string shortname { get; set; }
        public string phonecode { get; set; }
    }
}
