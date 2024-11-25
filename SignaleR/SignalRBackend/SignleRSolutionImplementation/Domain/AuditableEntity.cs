using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class AuditableEntity
    {
        public string   CreatedBy  { get; set; }
        public DateTime   CreatedOn  { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeletd { get; set; }
    }
}
