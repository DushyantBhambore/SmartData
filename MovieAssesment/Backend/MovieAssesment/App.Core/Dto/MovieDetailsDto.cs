using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Dto
{
    public class MovieDetailsDto
    {
        public int MovieId { get; set; }
        public string MoviTitle { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int ReleaseDate { get; set; }
        public IFormFile? Posterimage { get; set; }
    }
}
