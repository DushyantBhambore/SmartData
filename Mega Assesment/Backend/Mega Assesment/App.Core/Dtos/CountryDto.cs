﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Dtos
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string sortname { get; set; }
        public int phonecode { get; set; }
    }
}
