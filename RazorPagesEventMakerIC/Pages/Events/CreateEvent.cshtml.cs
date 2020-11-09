using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMakerIC.Models;

namespace RazorPagesEventMakerIC.Pages.Events
{
    public class CreateEventModel : PageModel
    {

        private FakeEventRepository repo;

        [BindProperty]
        public Event Event { get; set; }

        public CreateEventModel()
        {
            repo = new FakeEventRepository();
        }

        public IActionResult OnGet()
        {
            return Page();
        }


        public IActionResult OnPost()
        {
            repo.AddEvent(Event);
            return RedirectToPage("Index");
        }

    }

}
