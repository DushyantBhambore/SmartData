using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doamin
{
    public class AuditableEnity
    {
        public int id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string  CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public string  UpdatedBy { get; set; } = string.Empty;
        public DateTime UdatedOn { get; set; }
    }
}
