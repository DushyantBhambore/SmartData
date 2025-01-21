using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doamin
{
    public class MovieDetails : AuditableEnity
    {
        public int MovieId { get; set; }
        public string MoviTitle { get; set; } = string.Empty;
        public int ReleaseDate { get; set; }
        public int UserId { get; set; }
        public string Posterimage { get; set; } = string.Empty;
    }
}
    