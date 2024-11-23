using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Dto
{
    public class RoleDto : AuditableEntity
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
