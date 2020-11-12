using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace RazorPagesEventMakerIC.Models
{
    public class FakeEventRepository  //Skal implementeres som en singleton
    {
        private List<Event> events;

        private static FakeEventRepository _instance;
        private FakeEventRepository()
        {
            events = new List<Event>();
            events.Add(new Event()
            {
                Id = 1,
                Name = "Roskilde Festival",
                City = "Roskilde",
                Description = "A lot of music",
                DateTime = new DateTime(2020, 12, 13, 0, 0, 0)
            });
            events.Add(new Event()
            {
                Id = 2,
                Name = "Copenhagen Marathon",
                City = "Copenhagen",
                Description = "A long exercise run",
                DateTime = new DateTime(2020, 12, 23, 0, 0, 0)
            });
        }

        public static FakeEventRepository Instance
        {
            get
            {
                if (_instance==null)
                    _instance= new FakeEventRepository();
                return _instance;
            }
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

        public Event GetEvents(int id)
        {
            foreach (var v in events)
            {
                if (v.Id == id)
                {
                    return v;
                }
            }
            return new Event();
        }

        public void UpdateEvent(Event ev)
        {
            if (ev != null)
            {
                foreach (var e in events)
                {
                    if (e.Id == ev.Id)
                    {
                        e.Id = ev.Id;
                        e.Name = ev.Name;
                        e.City = ev.City;
                        e.Description = ev.Description;
                        e.DateTime = ev.DateTime;
                    }
                }
            }
        }

    }


}
