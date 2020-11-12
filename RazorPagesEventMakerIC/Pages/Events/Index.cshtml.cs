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

        [BindProperty(SupportsGet = true)]
        public DateTime DateFrom { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime DateTo { get; set; }


        public IndexModel()
        {
            DateFrom = DateTime.Now;
            DateTo = DateFrom.AddYears(1);
            repo = FakeEventRepository.Instance;// Der skal kun være et objekt af FakeEventRepository
        }
        public void OnGet()
        {
            if (Criteria == "" || Criteria == null)
                Events = (List<Event>)repo.GetAllEvents();
            else
            {
                Events = FilteredEvents();
            }
        }

        private List<Event> FilteredEvents()
        {
            List<Event> emptyList = new List<Event>();
            string lcriteria = Criteria.ToLower();

            foreach (Event e in (repo.GetAllEvents()))
            {
                string lName = e.Name.ToLower();
                string lCity = e.City.ToLower();
                string lDescription = e.Description.ToLower();
                //if (lName.Contains(lcriteria)  || lCity.Contains(lcriteria) || lDescription.Contains( lcriteria))
                if (e.DateTime>=DateFrom  && e.DateTime <= DateTo)
                    emptyList.Add(e);
            }
            return emptyList;
        }

    }

}
