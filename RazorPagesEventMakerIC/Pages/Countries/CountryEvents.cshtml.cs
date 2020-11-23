using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMakerIC.Interfaces;
using RazorPagesEventMakerIC.Models;

namespace RazorPagesEventMakerIC.Pages.Countries
{
    public class CountryEventsModel : PageModel
    {
        private IRepository repo;
        private ICountryRepository _crepo; 
        public Country ChoosenCountry { get; set; }

        public List<Event> Events { get; private set; }
        public CountryEventsModel(IRepository repository, ICountryRepository crepo )
        {
            repo = repository;
            _crepo = crepo;
        }

        

        public IActionResult OnGet(string code)
        {
            Events = new List<Event>();
            if (code == null)
            {
                return NotFound();
            }
            Events = repo.SearchEventsByCode(code);
            ChoosenCountry = _crepo.GetCountry(code);
            if (Events == null)
            {
                return NotFound();
            }
            return Page();
        }
    }

}
