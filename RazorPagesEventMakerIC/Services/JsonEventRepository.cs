using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesEventMakerIC.Helpers;
using RazorPagesEventMakerIC.Interfaces;
using RazorPagesEventMakerIC.Models;

namespace RazorPagesEventMakerIC.Services
{
    public class JsonEventRepository:IRepository
    {
        //private string filePath = @"C:\Users\EASJ\OneDrive - Zealand Sjællands Erhvervsakademi(1)\Dokumenter\UV\SWC2020E\mineprogramerVisualStudio\RazorPagesEventMakerIC\RazorPagesEventMakerIC\Data\jsonEvents.json";
        private string filePath = @"Data\jsonEvents.json";
        
        public List<Event> GetAllEvents()
        {
            return JsonFileReader.ReadJson(filePath);
        }

        public Event GetEvents(int id)
        {
            foreach (Event v in GetAllEvents())
            {
                if (v.Id == id)
                {
                    return v;
                }
            }
            return new Event();
        }

        public void AddEvent(Event ev)
        {
            List<int> eventsIds = new List<int>();
            List<Event> events = GetAllEvents();
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
            JsonFileWriter.WriteToJson(events,filePath);
        }

        public void UpdateEvent(Event ev)
        {
            if (ev != null)
            {
                List<Event> events = GetAllEvents();
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
                JsonFileWriter.WriteToJson(events,filePath);
            }
        }

        private List<Event> FilteredEventsDatesOnly(DateTime dateFrom, DateTime dateTo)
        {
            List<Event> emptyList = new List<Event>();


            foreach (Event e in GetAllEvents())
            {
                if (e.DateTime >= dateFrom && e.DateTime <= dateTo)
                    emptyList.Add(e);
            }
            return emptyList;
        }

        public List<Event> FilteredEvents(string criteria, DateTime dateFrom, DateTime dateTo)
        {
            if (criteria == "" || criteria == null)
                return FilteredEventsDatesOnly(dateFrom, dateTo);
            List<Event> emptyList = new List<Event>();
            string lcriteria = criteria.ToLower();

            foreach (Event e in GetAllEvents())
            {
                string lName = e.Name.ToLower();
                string lCity = e.City.ToLower();
                string lDescription = e.Description.ToLower();
                if (lName.Contains(lcriteria) || lCity.Contains(lcriteria) || lDescription.Contains(lcriteria))
                {
                    if (e.DateTime >= dateFrom && e.DateTime <= dateTo)
                        emptyList.Add(e);
                }

            }
            return emptyList;
        }

        public List<Event> SearchEventsByCode(string code)
        {
            throw new NotImplementedException();
        }
    }
}
