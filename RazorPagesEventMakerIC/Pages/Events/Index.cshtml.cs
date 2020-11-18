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

        //[BindProperty(SupportsGet = true)]
        [BindProperty]
        public string Criteria { get; set; }

        //[BindProperty(SupportsGet = true)]
        [BindProperty]
        public DateTime DateFrom { get; set; }

        //[BindProperty(SupportsGet = true)]
        [BindProperty]
        public DateTime DateTo { get; set; }


        public IndexModel()
        {
            DateFrom = DateTime.Now;
            DateTo = DateFrom.AddYears(1);
            repo = FakeEventRepository.Instance;// Der skal kun være et objekt af FakeEventRepository
        }
        public void OnGet()
        {
            Events = repo.FilteredEvents(Criteria, DateFrom, DateTo);
        }

        public void OnPost()
        {
            Events = repo.FilteredEvents(Criteria, DateFrom, DateTo);
        }

        

    }

}
