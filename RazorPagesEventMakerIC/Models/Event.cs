using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesEventMakerIC.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string CountryCode { get; set; }

        [Display(Name = "Event Name")]
        [Required(ErrorMessage = "Name of the Event is required"), MaxLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(18, ErrorMessage = "Name of the city can not be longer than 18 chars")]
        public string City { get; set; }

        [Range(typeof(DateTime), "10/1/2020", "10/12/2021", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime DateTime { get; set; }

    }

}
