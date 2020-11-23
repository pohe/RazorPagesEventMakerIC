using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesEventMakerIC.Models
{
    public class Country
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
    }

}
