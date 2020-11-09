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

        [BindProperty(SupportsGet = true)]
        public string Criteria { get; set; }

        public IndexModel()
        {
            repo = new FakeEventRepository();
        }
        public void OnGet()
        {
            if (Criteria == "" || Criteria == null)
                Events = (List<Event>)repo.GetAllEvents();
            else
            {
                Events = FilteredEvents(Criteria);
            }
            
        }

        private List<Event> FilteredEvents(string criteria)
        {
            List<Event> emptyList = new List<Event>();
            string lcriteria = criteria.ToLower();

            foreach (Event e in (repo.GetAllEvents()))
            {
                string lName = e.Name.ToLower();
                string lCity = e.City.ToLower();
                string lDescription = e.Description.ToLower();
                if (lName.Contains(lcriteria)  || lCity.Contains(lcriteria) || lDescription.Contains(criteria))
                    emptyList.Add(e);
            }

            return emptyList;
        }

    }

}
