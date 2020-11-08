using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMakerIC.Models;

namespace RazorPagesEventMakerIC.Pages.Events
{
    public class IndexModel : PageModel
    {
        private FakeEventRepository repo;
        public List<Event> Events { get; set; }

        public IndexModel()
        {
            repo = new FakeEventRepository();
        }
        public void OnGet()
        {
            Events = (List<Event>)repo.GetAllEvents();
        }
    }

}
