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
    public class CountryIndexModel : PageModel
    {
        public ICountryRepository repo { get; }

        public CountryIndexModel(ICountryRepository repository)
        {
            repo = repository;
        }

        public List<Country> Countries { get; private set; }

        public IActionResult OnGet()
        {
            Countries = repo.GetAllCountries();
            return Page();
        }
    }

}
