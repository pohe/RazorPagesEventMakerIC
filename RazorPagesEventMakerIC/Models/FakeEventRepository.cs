using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesEventMakerIC.Models
{
    public class FakeEventRepository
    {
        private List<Event> events { get; }

        public FakeEventRepository()
        {
            events = new List<Event>();
            events.Add(new Event()
            {
                Id = 1,
                Name = "Roskilde Festival",
                City = "Roskilde",
                Description = "A lot of music",
                DateTime = new DateTime(2020, 7, 3, 0, 0, 0)
            });
            events.Add(new Event()
            {
                Id = 2,
                Name = "Copenhagen Marathon",
                City = "Copenhagen",
                Description = "A long exercise run",
                DateTime = new DateTime(2020, 7, 3, 0, 0, 0)
            });
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return events.ToList();
        }

        public void AddEvent(Event ev)
        {
            List<int> eventsIds = new List<int>();

            foreach (var evt in events)
            {
                eventsIds.Add(evt.Id);
            }

            if (eventsIds.Count != 0)
            {
                int start = eventsIds.Max();
                ev.Id = start + 1;
            }
            else
            {
                ev.Id = 1;
            }
            events.Add(ev);
        }


    }


}
