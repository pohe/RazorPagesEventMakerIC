using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMakerIC.Interfaces;
using RazorPagesEventMakerIC.Models;
using RazorPagesEventMakerIC.Services;

namespace RazorPagesEventMakerIC.Pages.Events
{
    public class CreateEventModel : PageModel
    {

        private IRepository repo;

        [BindProperty]
        public Event Event { get; set; }

        public CreateEventModel(IRepository repository)
        {
            //repo = FakeEventRepository.Instance;
            repo = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            repo.AddEvent(Event);
            return RedirectToPage("Index");
        }

    }

}
