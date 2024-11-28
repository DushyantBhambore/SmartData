using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Dtos
{
    public class StateDto
    {
        public int Id { get; set; }

        public string StateName { get; set; }

        public int CountryId { get; set; }

    }
}
